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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static volatile string[,] CodeTable =
       {

            {"A","._"},

            {"B","_..."},

            {"C","_._."},

            {"D","_.."},

            {"E","."},

            {"E",".._.."},

            {"F",".._."},

            {"G","__."},

            {"H","...."},

            {"I",".."},

            {"J",".___"},

            {"K","_._"},

            {"L","._.."},

            {"M","__"},

            {"N","_."},

            {"O","___"},

            {"P",".__."},

            {"Q","__._"},

            {"R","._."},

            {"S","..."},

            {"T","_"},

            {"U",".._"},

            {"V","..._"},

            {"W",".__"},

            {"X","_.._"},

            {"Y","_.__"},

            {"Z","__.."},

            {"0","_____"},

            {"1",".____"},

            {"2","..___"},

            {"3","...__"},

            {"4","...._"},

            {"5","....."},

            {"6","_...."},

            {"7","__..."},

            {"8","___.."},

            {"9","____."},

            {".","._._._"},

            {",","__..__"},

            {":","___..."},

            {"?","..__.."},

            {"\'",".____."},

            {"_","_...._"},

            {"/","_.._."},

            {"(","_.__."},

            {")","_.__._"},

            {"\"","._.._."},

            {"=","_..._"},

            {"+","._._."},

            {"*","_.._"},

            {"@",".__._."},

        };

        private static volatile string[,] CodeTablex =
        {
        };

        public static string Enc(string str)

        {

            int i;

            string ret = string.Empty;

            if (str != null && (str = str.ToUpper()).Length > 0)

                foreach (char asc in str)

                    if ((i = Find(asc.ToString(), 0)) > -1)

                        ret += " " + CodeTable[i, 1];

            return ret;

        }

        private static int Find(string str, int cols)

        {

            int i = 0, len = CodeTable.Length / 2;

            while (i < len)

            {

                if (CodeTable[i, cols] == str)

                    return i;

                i++;

            };

            return -1;

        }

        public static string Dec(string str)

        {

            int i;

            string[] splits;

            string ret = string.Empty;

            if (str != null && (splits = str.Split(' ')).Length > 0)

            {

                foreach (string split in splits)

                    if ((i = Find(split, 1)) > -1)

                        ret += CodeTable[i, 0];

                return ret;

            }

            return "{#}";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex==0)
            {
                textBox.Text = Enc(textBox.Text);
            }
            else if (comboBox.SelectedIndex == 1)
            {
                byte[] bytes = Encoding.Default.GetBytes(textBox.Text);
                textBox.Text= Convert.ToBase64String(bytes);  
            }
            else if (comboBox.SelectedIndex == 2)
            {
               // int n;
                if (textBox.Text.Length == 8/*&&int.TryParse(textBox.Text,out n)*/)
                {
                    textBox.Text = "http://pan.baidu.com/s/" + textBox.Text;
                }
            }
            else if (comboBox.SelectedIndex == 3)
            {
                if (textBox.Text.Length == 40 )
                {
                    textBox.Text = "magnet:? xt = urn : btih:" + textBox.Text;
                }
            }

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            if (comboBox.SelectedIndex == 0)
            {
                textBox.Text = Dec(textBox.Text);
            }
            else if (comboBox.SelectedIndex == 1)
            {
                byte[] outputb = Convert.FromBase64String(textBox.Text);
                textBox.Text= Encoding.Default.GetString(outputb);
            }
            else if (comboBox.SelectedIndex == 2)
            {
                byte[] bytes = Encoding.Default.GetBytes(textBox.Text);
                textBox.Text = Convert.ToBase64String(bytes);
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
