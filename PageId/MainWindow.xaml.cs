using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IrrKlang;
using System.Speech.Synthesis;
using System.IO;

namespace PageId
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        string pageSynthesis;

        ISound PlayingSound;
        ISoundEngine sound = new ISoundEngine();
        string soundfile;
        string currentFile = "";

        private StreamWriter logFile;
        
        int bitOne = 0;
        int bitTwo = 0;
        int bitThree = 0;
        int bitFour = 0;
        string pageCode;

        public MainWindow()
        {
            //creates a logfile with valid characters of the current DateTime
            DateTime date = DateTime.Now;
            string dateString = date.ToString();
            string myNewDate = dateString.Replace('/', ' ');
            string myLastDate = myNewDate.Replace(':', '-');
            string myLog = myLastDate + ".txt";
            logFile = new StreamWriter(myLog);
            logFile.WriteLine("start");


            InitializeComponent();
            MainCanvas.TouchDown += MainCanvas_TouchDown;
            MainCanvas.TouchUp += MainCanvas_TouchUp;
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            
        }

        private void MainCanvas_TouchDown(object sender, TouchEventArgs e)
        {
            //get the coordinates for the current touch point
            TouchPoint pointFromWindow = e.GetTouchPoint(this);
            //translate to coordinates relative to Top-Left corner of Screen
            Point locationFromScreen = this.PointToScreen(new Point(pointFromWindow.Position.X, pointFromWindow.Position.Y));
            Console.WriteLine(pointFromWindow.Position.X + "," + pointFromWindow.Position.Y);

            //binary coding for the upper part in each quarter of the screen
            if (pointFromWindow.Position.Y < 80)
            {
                if (pointFromWindow.Position.X <(720/4)*1)
                {
                    bitOne = 1;
                }
                if (pointFromWindow.Position.X > (720 / 4) * 1 & pointFromWindow.Position.X < (720 / 4) * 2)
                {
                    bitTwo = 1;
                }
                if (pointFromWindow.Position.X > (720 / 4) * 2 & pointFromWindow.Position.X < (720 / 4) * 3)
                {
                    bitThree = 1;
                }
                if (pointFromWindow.Position.X > (720 / 4) * 3 & pointFromWindow.Position.X < (720 / 4) * 4)
                {
                    bitFour = 1;
                }
                //binary number combined
                pageCode = bitFour.ToString() + bitThree.ToString() + bitTwo.ToString() + bitOne.ToString();

                //page selection depending on the flopper code
                if (pageCode == "0001")
                {
                    Tabchanger.SelectedIndex = 1;                   
                }
                else if (pageCode == "0010")
                {                    
                    Tabchanger.SelectedIndex = 2;
                }
                else if (pageCode == "0011")
                {
                    Tabchanger.SelectedIndex = 3;
                }
                else if (pageCode == "0100")
                {                    
                    Tabchanger.SelectedIndex = 4;
                }
                else if (pageCode == "0101")
                {
                    Tabchanger.SelectedIndex = 5;  
                }
                else if (pageCode == "0110")
                {
                    Tabchanger.SelectedIndex = 6;
                }
                else if (pageCode == "0111")
                {
                    Tabchanger.SelectedIndex = 7;
                }
                else if (pageCode == "1000")
                {
                    Tabchanger.SelectedIndex = 8;
                }
                else if (pageCode == "1001")
                {
                    Tabchanger.SelectedIndex = 9;
                }
                else if (pageCode == "1010")
                {
                    Tabchanger.SelectedIndex = 10;                   
                }
                else if (pageCode == "1011")
                {
                    Tabchanger.SelectedIndex = 11;                   
                }
                else if (pageCode == "1100")
                {
                    Tabchanger.SelectedIndex = 12;                                     
                }
                else if (pageCode == "1101")
                {
                    Tabchanger.SelectedIndex = 13;                 
                }
                else
                {                    
                    Tabchanger.SelectedIndex = 0;                    
                }
            }
        }

        private void MainCanvas_TouchUp(object sender, TouchEventArgs e)
        {
            TouchPoint pointFromWindow = e.GetTouchPoint(this);
            //translate to coordinates relative to Top-Left corner of Screen
            Point locationFromScreen = this.PointToScreen(new Point(pointFromWindow.Position.X, pointFromWindow.Position.Y));
            if (pointFromWindow.Position.Y < 100 && pointFromWindow.Position.X < 800)
            {
                bitOne = bitTwo = bitThree = bitFour = 0;
                pageCode = "0000";                
            }
        }

        //function for each button (activate sound file, write the activation line into the log file)
        private void Page19_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page19-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page19_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page19-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page19_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page19-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page19_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page19-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page19_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page19-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page19_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page19-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button1_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page20-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button1_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-20-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button2_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page20-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button2_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-20-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page20-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page20-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page20_Button5_Click(object sender, EventArgs e)
        {                     
            soundfile = "page20-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page21-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page21-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page21-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page21-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page21-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page21-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page21-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page21_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page21-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page22-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page22-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page22-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page22-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button6_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page22-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button6_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-22-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page22_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page22-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button1_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page23-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button1_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-23-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page23-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page23-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button4_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page23-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button4_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-23-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page23-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page23-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button7_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page23-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }
        private void Page23_Button7_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-23-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page23-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button9_Click(object sender, EventArgs e)
        {
            soundfile = "page23-9.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button10_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page23-10.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button10_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-23-10.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page23_Button11_Click(object sender, EventArgs e)
        {
            soundfile = "page23-11.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page24-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page24-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page24-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page24-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page24-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page24-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page24-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page24_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page24-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button1_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page25-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button1_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-25-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page25-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page25-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page25-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page25-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page25-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page25-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page25-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page25_Button9_Click(object sender, EventArgs e)
        {
            soundfile = "page25-9.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page26-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page26-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page26-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page26-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page26-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page26-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page26-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page26-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button9_Click(object sender, EventArgs e)
        {
            soundfile = "page26-9.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button10_Click(object sender, EventArgs e)
        {
            soundfile = "page26-10.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button11_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page26-11.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button11_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-26-11.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button12_Click(object sender, EventArgs e)
        {
            soundfile = "page26-12.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button13_Click(object sender, EventArgs e)
        {
            soundfile = "page26-13.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button14_Click(object sender, EventArgs e)
        {
            soundfile = "page26-14.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page26_Button15_Click(object sender, EventArgs e)
        {
            soundfile = "page26-15.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page27-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page27-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page27-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page27-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page27-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page27-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page27_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page27-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page28-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page28-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page28-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page28-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button5_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page28-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button5_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-28-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page28-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page28-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page28-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button9_Click(object sender, EventArgs e)
        {
            soundfile = "page28-9.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page28_Button10_Click(object sender, EventArgs e)
        {
            soundfile = "page28-10.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page29-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page29-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page29-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page29-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button5_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page29-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page29-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button7_Click(object sender, EventArgs e)
        {
            soundfile = "page29-7.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button8_Click(object sender, EventArgs e)
        {
            soundfile = "page29-8.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button9_Click(object sender, EventArgs e)
        {
            soundfile = "page29-9.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button10_Click(object sender, EventArgs e)
        {
            soundfile = "page29-10.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button11_Click(object sender, EventArgs e)
        {
            soundfile = "page29-11.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page29_Button12_Click(object sender, EventArgs e)
        {
            soundfile = "page29-12.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page30-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page30-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page30-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page30-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button5_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "page30-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button5_Hl(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            soundfile = "highlighted-page-30-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page30_Button6_Click(object sender, EventArgs e)
        {
            soundfile = "page30-6.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page31_Button1_Click(object sender, EventArgs e)
        {
            soundfile = "page31-1.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page31_Button2_Click(object sender, EventArgs e)
        {
            soundfile = "page31-2.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page31_Button3_Click(object sender, EventArgs e)
        {
            soundfile = "page31-3.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page31_Button4_Click(object sender, EventArgs e)
        {
            soundfile = "page31-4.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        private void Page31_Button5_Click(object sender, EventArgs e)
        {
            soundfile = "page31-5.mp3";
            activator(soundfile);
            logFile.WriteLine(DateTime.Now.ToString() + " " + soundfile);
        }

        //takes file name as a string parameter and activates the corresponding mp3 file
        private void activator(string file)
        {
            if (PlayingSound == null)
            {
                PlayingSound = sound.Play2D(file, false);
                currentFile = soundfile;

            }
            if (PlayingSound != null && PlayingSound.Paused == false && currentFile==soundfile)
            {               
                    PlayingSound.Paused = true;            
            }
            else if(PlayingSound != null && PlayingSound.Paused == true)
            {
                if (currentFile == soundfile)
                {
                    PlayingSound.Paused = false;
                }
                else
                {
                    PlayingSound = sound.Play2D(file, false);
                    currentFile = soundfile;
                }
                
            }
           
            if (PlayingSound.Finished == true)
            {
                
                PlayingSound = sound.Play2D(file, false);
                
                
            }
            
        }

        //writes end and closes the program and saves the log file, if Esc is pressed on the keyboard
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                logFile.WriteLine("end");
                logFile.Close();
                Close();
            }               
        }

        //page synthesis for each tab. for touch and keyboard use.
        private void Tabchanger_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (page1.IsSelected)
            {
                pageSynthesis = "page one";
                speechSynthesizer.SpeakAsync(pageSynthesis);
                
            }
            if (page2.IsSelected)
            {
                pageSynthesis = "page two";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page3.IsSelected)
            {
                pageSynthesis = "page three";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page4.IsSelected)
            {
                pageSynthesis = "page four";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page5.IsSelected)
            {
                pageSynthesis = "page five";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page6.IsSelected)
            {
                pageSynthesis = "page six";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page7.IsSelected)
            {
                pageSynthesis = "page seven";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page8.IsSelected)
            {
                pageSynthesis = "page eight";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page9.IsSelected)
            {
                pageSynthesis = "page nine";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page10.IsSelected)
            {
                pageSynthesis = "page ten";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page11.IsSelected)
            {
                pageSynthesis = "page eleven";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page12.IsSelected)
            {
                pageSynthesis = "page twelve";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page13.IsSelected)
            {
                pageSynthesis = "page thirteen";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            if (page0.IsSelected)
            {
                pageSynthesis = "page zero";
                speechSynthesizer.SpeakAsync(pageSynthesis);
            }
            logFile.WriteLine(DateTime.Now.ToString() + " "+ pageSynthesis);
        }
    }
}
