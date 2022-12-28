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

namespace WpfCurentCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        double R50_51=20.769, R51_52=25.1335;
        double U2750, U11050, U2751, U11051, U2752, U11052;
        const double RPN = 4.356;



        public MainWindow()
        {
            InitializeComponent();



        }

        //private void Gridchange(object sender, RoutedEventArgs e)
        //{
        //    double dU50_51 = U2750 - U2751;
        //    double I50_51 = dU50_51 / R50_51;
        //    TB_I5051.Text = I50_51.ToString();
        //}

        ///при изменении текста во 2 ячейке расчитывает U27.5 выводит значение в ячейку ниже
        private void TextBox_TextChanged_50(object sender, TextChangedEventArgs e)
        {
            try
            {
                U11050 = Convert.ToDouble(TB_U110_50.Text); //ввод значения напряжения ВН из TextBox в формулу
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                U2750 = U11050 * Math.Sqrt(3) / 4.356;

            TB_U27_50.Text = U2750.ToString("0.0"); //вывод значения напряжения НН в TextBlok



        }

        //при изменении текста во 2 ячейке расчитывает U27.5 выводит значение в ячейку ниже, расчитывает Iур выводит значение в ячейку ниже

        private void TextBox_TextChanged_51(object sender, TextChangedEventArgs e)
        {
            try
            {
                U11051 = Convert.ToDouble(TB_U110_51.Text); //ввод значения напряжения ВН из TextBox в формулу
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            U2751 = U11051 * Math.Sqrt(3) / 4.356;

            TB_U27_51.Text = U2751.ToString("0.0"); //вывод значения напряжения НН в TextBlok

            if (U2750 != 0 && U2751 != 0) //расчет уравнительного тока ЭЧЭ50-ЭЧЭ51
            {
                double dU50_51 = U2750 - U2751;
                double I50_51 = dU50_51 / R50_51;
                TB_I5051.Text = I50_51.ToString("0.0");
            }

        }

        //при изменении текста в 3 ячейке расчитывает U27.5 выводит значение в ячейку ниже, расчитывает Iур выводит значение в ячейку ниже
        private void TextBox_TextChanged_52(object sender, TextChangedEventArgs e)
        {
            try
            {
                U11052 = Convert.ToDouble(TB_U110_52.Text); //ввод значения напряжения ВН из TextBox в формулу
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            U2752 = U11052 * Math.Sqrt(3) / RPN;
            TB_U27_52.Text = U2752.ToString("0.0"); //вывод значения напряжения НН в TextBlok

            if (U2751 != 0 && U2752 != 0) //расчет уравнительного тока ЭЧЭ51-ЭЧЭ52
            {
                double dU50_52 = U2751 - U2752;
                double I50_52 = dU50_52 / R51_52;
                TB_I5052.Text = I50_52.ToString("0.0");
            }

        }





    
    }
}
