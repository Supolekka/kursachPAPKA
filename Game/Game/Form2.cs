using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form2 : Form
    {
        // Генерация рандомных чисел
        Random randomizer = new Random();
        // Переменные
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;
        public Form2()
        {
            InitializeComponent();
        }
        public void StartTheQuiz()
        {
            // Два числа (сложение)
            addend1 = randomizer.Next(150);
            addend2 = randomizer.Next(100);

            // Преобразуем рандомные числа в строки
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum1.Value = 0;

            // Два числа (вычитание)
            minuend = randomizer.Next(100, 200);
            subtrahend = randomizer.Next(100, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Два числа (умножение)
            multiplicand = randomizer.Next(4, 13);
            multiplier = randomizer.Next(4, 13);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Два числа (деление)
            divisor = randomizer.Next(2, 22);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Запуск таймера
            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum1.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // Если пользователь ответит правильно на вопросы, то отсановится таймер и выведется окно "Выигрыш"
                timer1.Stop();
                MessageBox.Show("Отлично, ты справился.",
                                "Поздравления!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Отсчет времени
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " секунд";
            }
            else
            {
                // Если таймер пройдет, выведется окно "Проигрыш", также в окне для ответов появятся правильные ответы
                timer1.Stop();
                timeLabel.Text = "Время закончилось:(";
                MessageBox.Show("Ты не успел.", "Эх-эх-эхушки...");
                sum1.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }
    }
}
