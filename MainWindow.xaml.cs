using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezese();
        }

        private void GombokElhelyezese()
        {
            // Gombok elhelyezése a Grid-ben
            for (int i = 0; i < 4; i++)
            {
                ButtonGrid.RowDefinitions.Add(new RowDefinition());
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());
                
            }
            string[,] feliratok = new string[,]
            {
                { "7", "8", "9", "/" },
                { "4", "5", "6", "*" },
                { "1", "2", "3", "-" },
                { "C", "0", "=", "+" }
            };  

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string label = feliratok[i, j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };
                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = Brushes.WhiteSmoke;
                    }
                    else if (label == "C")
                    {
                        btn.Background = Brushes.IndianRed;
                        btn.Foreground = Brushes.White;
                    }
                    else
                    {
                        btn.Background = Brushes.DodgerBlue;
                        btn.Foreground = Brushes.White;
                    }

                    btn.Click += Button_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    ButtonGrid.Children.Add(btn);
                }
            }

        }

        List<string> muveletek = ["+","-","/","*","=" ];
        string muvelet;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string felirat = button.Content.ToString();

            tb_kijelzo.Text += felirat;
            if (felirat == "C")
            {
                tb_kijelzo.Text = string.Empty;
            }
            if ((tb_kijelzo.Text.Contains(muveletek[0]) || tb_kijelzo.Text.Contains(muveletek[1]) || tb_kijelzo.Text.Contains(muveletek[2]) || tb_kijelzo.Text.Contains(muveletek[3])) && tb_kijelzo.Text.Contains(muveletek[4]))
            {
                if (tb_kijelzo.Text.Contains(muveletek[0]))
                {
                    muvelet = muveletek[0];
                }
                else if (tb_kijelzo.Text.Contains(muveletek[1]))
                {
                    muvelet = muveletek[1];
                }
                else if (tb_kijelzo.Text.Contains(muveletek[2]))
                {
                    muvelet = muveletek[2];
                }
                else if (tb_kijelzo.Text.Contains(muveletek[3]))
                {
                    muvelet = muveletek[3];
                }
                tb_kijelzo.Text = tb_kijelzo.Text.Replace(muveletek[4], string.Empty);
                string[] szamok = tb_kijelzo.Text.Split(muvelet);
                if (szamok.Length == 2)
                {
                    int szam1 = Convert.ToInt32(szamok[0]);
                    int szam2 = Convert.ToInt32(szamok[1]);
                    double eredmeny = 0;
                    if (tb_kijelzo.Text.Contains(muveletek[0]))
                    {
                        eredmeny = szam1 + szam2;
                    }
                    else if (tb_kijelzo.Text.Contains(muveletek[1]))
                    {
                        eredmeny = szam1 - szam2;
                    }
                    else if (tb_kijelzo.Text.Contains(muveletek[2]))
                    {
                        eredmeny = szam1 / szam2;
                    }
                    else if (tb_kijelzo.Text.Contains(muveletek[3]))
                    {
                        eredmeny = szam1 * szam2;
                    }
                    tb_kijelzo.Text = eredmeny.ToString();
                }

            }
        }
    }
}