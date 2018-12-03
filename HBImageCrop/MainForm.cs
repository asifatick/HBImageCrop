using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HBImageCrop
{
    public partial class MainForm : Form
    {
        public Project _currentProject = new Project();
        private string SourcePath;
        private int currentIndex = 0;
        public Img ActiveImage = new Img();
        public Image ActiveViewableImage;
        private Point currentPos;
        private Point startPos;
        private bool drawing;
        public string CroppedPath = "\\Cropped\\";
        public string ResizePath = "\\Resized\\";
        double aspectRatio = 1;
        int selectionCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtwainImagelist.SetViewMode(1, 8);
            dtwainImagelist.LicenseKeys = "F4E6B87C454944CB24705D558C4C9E4C;C9164EBE9DC183CAC2CE69621C0AE76B;266653AFD4CF1476C43DCC99919C76AE";
            dtMain.LicenseKeys = "F4E6B87C454944CB24705D558C4C9E4C;C9164EBE9DC183CAC2CE69621C0AE76B;266653AFD4CF1476C43DCC99919C76AE";
            dtMain.MaxImagesInBuffer = 1;
            aspectRatio = (double)(nudWidth.Value / nudHeight.Value);
            dtMain.SelectionRectAspectRatio = aspectRatio;
            dtMain.SetViewMode(-1, -1);

            dtMain.IfFitWindow = false;

           
        }

        private void btnOpenImageFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog opener = new FolderBrowserDialog();
            //opener. = "Jpg|*.jpg |Jpeg |*.jpeg |Png |*.png ";
            DialogResult res = opener.ShowDialog();
            if (!string.IsNullOrWhiteSpace(opener.SelectedPath))
            {
                OpenSourceFolder(opener.SelectedPath);
            }
        }
        private void OpenSourceFolder(string Path)
        {
            SourcePath = Path;
          

            List<string> files = Directory.EnumerateFiles(SourcePath).Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png")).ToList();
            //
            clbImageList.Items.Clear();
            dtwainImagelist.RemoveAllImages();
            foreach (var item in files)
            {
                dtwainImagelist.LoadImage(item);
                clbImageList.Items.Add(item);

            }
            _currentProject.LastActiveSourceFolder = SourcePath;
            //updateProjectJson();
            if (clbImageList.Items.Count > 0)
            {
                clbImageList.SetItemCheckState(0, CheckState.Checked);
                dtwainImagelist.CurrentImageIndexInBuffer = 0;
                dtwainImagelist_OnMouseClick(0);
            }
            Directory.CreateDirectory(_currentProject.LastActiveSourceFolder + CroppedPath);
            Directory.CreateDirectory(_currentProject.LastActiveSourceFolder + ResizePath);
        }

        private void clbImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelctionChanges(clbImageList.SelectedIndex);
        }
        private void SelctionChanges(int selectionIndex)
        {
            string selectedimagepath = clbImageList.GetItemText(clbImageList.Items[selectionIndex]);
            currentIndex = selectionIndex;
            try
            {
               // pictureBox1.Load(selectedimagepath);
                ActiveViewableImage = Image.FromFile(selectedimagepath);


                ActiveImage = new Img();
                ActiveImage.Id = Guid.NewGuid().ToString();
                ActiveImage.OriginalName = selectedimagepath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Image Selected");
            }

            try
            {

              
                if (_currentProject.Images.Any(i => i.OriginalName == selectedimagepath))
                {
                    ActiveImage = _currentProject.Images.Single(i => i.OriginalName == selectedimagepath);
                    List<ImgLabel> labels = ActiveImage.AnnotatedLabels;
                   

                }

            }
            catch (Exception ex1)
            {

                Console.WriteLine("No Image Data");
            }
        }

        private void clbImageList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clbImageList.SelectedIndex = e.Index;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            {
                drawing = true;
                currentPos = startPos = e.Location;
               

            }
            else
            { drawing = false;

               
                Image image = Image.FromFile(ActiveImage.OriginalName);
                Image newSlice = new Bitmap((int)nudHeight.Value, (int)nudWidth.Value);
                using (Graphics gr = Graphics.FromImage(newSlice))
                {
                    gr.DrawImage(image, new Rectangle(0, 0, (int)nudHeight.Value, (int)nudWidth.Value), new Rectangle(currentPos.X, currentPos.Y, (int)nudHeight.Value, (int)nudWidth.Value), GraphicsUnit.Pixel);
                }

                newSlice.Save(_currentProject.LastActiveSourceFolder + CroppedPath + ActiveImage.OriginalName.Split('\\').Last());


            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
           // if (drawing) pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, new Rectangle { Location= currentPos,Height =(int)nudHeight.Value, Width= (int)nudWidth.Value} );
        }

    

        private void dtwainImagelist_OnMouseClick(short sImageIndex)
        {
            selectionCount = 0;
            //Copy the image you just clicked in the thumbnails
            dtwainImagelist.CopyToClipboard(sImageIndex);
            //Load the same image in the main viewer
            dtMain.LoadDibFromClipboard();
            clbImageList.SelectedIndex = sImageIndex;
            rbCrop_CheckedChanged(null, null);
        }

        private void dtMain_OnImageAreaSelected(short sImageIndex, int left, int top, int right, int bottom)
        {
           

        }

        private void rbCrop_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrop.Checked)
            {
                dtMain.SetSelectionRectPosition(0, 0, 0, (int)nudWidth.Value, (int)nudHeight.Value);
                
            }
            else
            {
                dtMain.SelectionRectAspectRatio = aspectRatio;
            }
        }

        private void dtMain_OnMouseRightClick(short sImageIndex)
        {
            
            Rectangle selection = dtMain.GetSelectionRect(0);
            string fileName = ActiveImage.OriginalName.Split('\\').Last();
            fileName = fileName.Split('.')[0] + "_" + selectionCount .ToString()+"."+ fileName.Split('.')[1];
            if (rbCrop.Checked)
            {
                dtMain.Crop(0, selection.Left, selection.Top, selection.Right, selection.Bottom);
                dtMain.SaveAsJPEG(_currentProject.LastActiveSourceFolder + CroppedPath + fileName, 0);
                dtMain.LoadDibFromClipboard();
                dtMain.SetSelectionRectPosition(0, 0, 0, (int)nudWidth.Value, (int)nudHeight.Value);

            }
            else
            {
                
                dtMain.SelectionRectAspectRatio = aspectRatio;
                dtMain.Crop(0, selection.Left, selection.Top, selection.Right, selection.Bottom);
                dtMain.ChangeImageSize(0, (int)nudWidth.Value, (int)nudHeight.Value,Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.BestQuality);

                dtMain.SaveAsJPEG(_currentProject.LastActiveSourceFolder + ResizePath + fileName, 0);



                dtMain.LoadDibFromClipboard();
            }
            selectionCount++;
        }

        private void dtMain_OnMouseClick(short sImageIndex)
        {
            //if (rbCrop.Checked)
            //{
            //    dtMain.SetSelectionRectPosition(0, 0, 0, (int)nudWidth.Value + 1, (int)nudHeight.Value + 1);

            //}
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            aspectRatio = (double)(nudWidth.Value / nudHeight.Value);
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            aspectRatio = (double)(nudWidth.Value / nudHeight.Value);
        }

        private void dtMain_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                int index = dtwainImagelist.CurrentImageIndexInBuffer+1;
                dtwainImagelist_OnMouseClick((short)index );

            }
        }

        private void dtMain_OnDNTKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int index = dtwainImagelist.CurrentImageIndexInBuffer + 1;
                if (index < dtwainImagelist.HowManyImagesInBuffer)
                {
                    dtwainImagelist.CurrentImageIndexInBuffer = (short)index;
                    dtwainImagelist_OnMouseClick((short)index);
                }

            }
        }
    }
}
