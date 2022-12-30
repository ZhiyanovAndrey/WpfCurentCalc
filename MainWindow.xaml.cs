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

        
        double R50_51 = 20.769, R51_52 = 25.1335, rpn50, rpn;
        double U2750, U11050, U2751, U11051, U2752, U11052;

     

        public double ConvertRPN(int swrpn)
        {
            switch (swrpn)
            {
                case 1: return 3.605;
                case 2: return 3.668;
                case 3: return 3.734;
                case 4: return 3.802;
                case 5: return 3.872;
                case 6: return 3.945;
                case 7: return 4.021;
                case 8: return 4.099;
                case 9: return 4.182;
                case 10: return 4.182;
                case 11: return 4.182;
                case 12: return 4.267;
                case 13: return 4.356;
                case 14: return 4.449;
                case 15: return 4.546;
                case 16: return 4.647;
                case 17: return 4.752;
                case 18: return 4.863;
                case 19: return 4.978;

            }
            return swrpn;
        }

        public String CalculateU2750 (double U110,double rpn )
        {
            U2750 = U110 * Math.Sqrt(3) / rpn;

            return U2750.ToString("0.0");
        }

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
  //при изменении слайдера  расчитывает U27.5 выводит значение в ячейку ниже
        private void rpn50_sld_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            rpn50 = ConvertRPN(Convert.ToInt32(rpn50_sld.Value)); //ввод значения РПН из TextBox

               
            if (TB_U27_50 != null) TB_U27_50.Text = CalculateU2750(U11050, rpn50); //вывод значения напряжения НН в TextBlok
        }
       
        //при изменении текста ячейке 1 Напряжение 110 кВ расчитывает напряжение 27.5 выводит значение в ячейку ниже
        private void TextBox_TextChanged_50(object sender, TextChangedEventArgs e)
        {
            try
            {
                U11050 = Convert.ToDouble(TB_U110_50.Text); //ввод значения напряжения ВН из TextBox
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TB_U27_50.Text = CalculateU2750(U11050, rpn50);




        }

        //при изменении текста ячейке 2 Напряжение 110 кВ расчитывает напряжение 27.5 выводит значение в ячейку ниже
        //расчитывает Iур выводит значение в ячейку ниже

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
            U2752 = U11052 * Math.Sqrt(3) / 4.356;
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
