using System.Diagnostics;

namespace Interface
{
    public partial class Form1 : Form
    {
        Stopwatch watch;
        public Form1()
        {
            InitializeComponent();
            watch = new Stopwatch();
            watch.Start();
        }

        private async Task btn_iniciar_ClickAsync(object sender, EventArgs e)
        {

            await VisualizaRelogio2();
        }

        void VisualizaRelogio()
        {
            var otherThread = new Thread(() =>
           {
               while (true)
               {
                   Thread.Sleep(100);
                   TimeSpan time = watch.Elapsed;
                   int min = time.Minutes;
                   int sec = time.Seconds;
                   int mili = time.Milliseconds;
                   this.Invoke((Action)delegate
                    {
                        lbl_secs.Text = $"{min:00}   |      {sec:00}    |       {mili:00}";
                    });
               }
           });
            otherThread.Start();

        }

        async Task VisualizaRelogio2()
        {
            while (true)
            {
                await Task.Delay(100);

                TimeSpan time = watch.Elapsed;
                int min = time.Minutes;
                int sec = time.Seconds;
                int mili = time.Milliseconds;
                lbl_secs.Text = $"{min:00}   |      {sec:00}    |       {mili:00}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
