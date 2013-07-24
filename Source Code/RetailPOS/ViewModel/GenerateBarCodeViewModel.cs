using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.CommonLayer.BarCodeGenerator;
using System.Windows.Forms;
using System.Drawing;


namespace RetailPOS.ViewModel
{
   public class GenerateBarCodeViewModel:ViewModelBase
    {
       public RelayCommand <Object>CmdEncode { get; private set; }
       public RelayCommand CmdSaveAs { get; private  set; }
       private string _valueToEncode;
       private int _width;
       private int _height;
       private string _encodedValue;
       //Barcode b = new Barcode();

       public string EncodedValue
       {
           get
           {
               return _encodedValue;
           }
           set
           {
               _encodedValue = value;
               RaisePropertyChanged("EncodedValue");
           }
       }

       public string ValueToEncode
       {
           get { return _valueToEncode; }
           set
           {
               _valueToEncode = value;
               RaisePropertyChanged("ValueToEncode");
           }
       }

       public int Width
       {
           get { return _width; }
           set
           {
               _width = value;
               RaisePropertyChanged("Width");
           }
       }

       public int Height
       {
           get { return _height; }
           set
           {
               _height = value;
               RaisePropertyChanged("Height");
           }
       }

       public GenerateBarCodeViewModel()
       {
           InitaliseCtrl();
           CmdEncode = new RelayCommand<object>(EncodeValue);
           CmdSaveAs = new RelayCommand(SaveImage);

       }

       private void SaveImage()
       {
           SaveFileDialog sfd = new SaveFileDialog();
           sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
           sfd.FilterIndex = 2;
           sfd.AddExtension = true;
           if (sfd.ShowDialog() == DialogResult.OK)
           {
               SaveTypes savetype = SaveTypes.UNSPECIFIED;
               switch (sfd.FilterIndex)
               {
                   case 1: /* BMP */  savetype = SaveTypes.BMP; break;
                   case 2: /* GIF */  savetype = SaveTypes.GIF; break;
                   case 3: /* JPG */  savetype = SaveTypes.JPG; break;
                   case 4: /* PNG */  savetype = SaveTypes.PNG; break;
                   case 5: /* TIFF */ savetype = SaveTypes.TIFF; break;
                   default: break;
               }//switch
               //b.SaveImage(sfd.FileName, savetype);
           }//if
       }

       private void EncodeValue(object obj)
       {
           var barcode = obj as  PictureBox ;
          
           var W = Width;
           var H = Height;
           b.Alignment = AlignmentPositions.CENTER;
           var type = TYPE.EAN13;
           b.IncludeLabel = true;
           b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "rotatenoneflipnone", true);
           barcode.Image = b.Encode(type, ValueToEncode, Color.Black, Color.White, W, H);
           //===================================

           //show the encoding time
         // var val  = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";

          EncodedValue = b.EncodedValue;

         // var encodedType = "Encoding Type: " + b.EncodedType.ToString();

          barcode.Width = barcode.Image.Width;
          barcode.Height = barcode.Image.Height;

          //reposition the barcode image to the middle
          //barcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);

       }

       private void InitaliseCtrl()
       {
           Width = 300;
           Height = 150;

       }
    }
}
