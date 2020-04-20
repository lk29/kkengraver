// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.Form1
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D85B3EF6-6EAE-4E7B-9FA6-02FD579957F4
// Assembly location:  Laser engraving machine.exe
// lk29

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace 微型雕刻机2
{
  public class Form1 : Form
  {
    private int[] zysx = new int[4];
    private Point[] zhixian = new Point[0];
    private string wenben = "";
    private int[] hua_kg = new int[2];
    private string wen_jian_ming = "";
    private Point yi_dian = new Point();
    private Point wz_weizhi = new Point(0, 0);
    private bool wzms = true;
    private string str1 = "scaling";
    private string str2 = "attach device";
    private string str3 = "disconnect device";
    private string str4 = "import pictures";
    private string str5 = "input text";
    private string str6 = "enter key";
    private string str7 = "start";
    private string str8 = "pause";
    private string str9 = "continue";
    private string str10 = "stop";
    private string str11 = "choose engraving model";
    private string str12 = "black and white";
    private string str13 = "discrete engraving";
    private string str14 = "gray scale";
    private string str15 = "picture adjustment";
    private string str16 = "Depth adjustment of engraving";
    private string str17 = "depth of caving";
    private string str18 = "laser positioning";
    private string str19 = "back to center";
    private string str20 = "frame positioning";
    private string str21 = "back to starting point";
    private string str22 = "device has been disconnected! ";
    private string str23 = "please connect device first! ";
    private string str24 = "please input picture or words first! ";
    private string str25 = "being engraved! ";
    private string str26 = "engraving completed!";
    private string str27 = "failto connect device,please check if USB is attatched and driver is properly installed. ";
    private string str28 = "laser engraving machine";
    private string str29 = "please no longer input words. ";
    private string str30 = "receive error! ";
    private string str31 = "time cost:";
    private string str32 = "minutes";
    private string str33 = "seconds";
    private string str34 = "pictures";
    private string str35 = "please stop frame positoning!";
    private string str36 = "enlarge";
    private string str37 = "Laser power adjustment";
    private diao_ke_ji diao;
    public int dx;
    public int dy;
    private int zhuang_tai;
    public int x;
    public int y;
    private int wei_zhi;
    private bool hua2;
    private bool anxia;
    private bool anxia2;
    private bool ting_zhi;
    private bool ca;
    private bool g_daima;
    private int suofang;
    public Form guan;
    private Bitmap tu;
    private bool fan_se;
    private int wen_zi_x;
    private int wen_zi_y;
    private Font ziti;
    private bool anxia3;
    private bool kuang;
    private int shu_x;
    private int shu_y;
    public int hua_kuan;
    public int hua_gao;
    private bool fen;
    private bool kai_shi;
    private bool gai_bian;
    private bool feng_shang;
    private bool zan_ting;
    private bool zan_ting2;
    private bool an_xia;
    private bool bjk_anxia;
    private int bjk_x;
    private int bjk_y;
    private Bitmap w_z;
    private int hei_dian_shu;
    private int miao60;
    private int shi_jian;
    private int gong_lv;
    private bool jk;
    private int shubiao_x;
    private int shubiao_y;
    private int miao;
    private IContainer components;
    private Panel panel1;
    private Button button1;
    private CheckBox checkBox1;
    private Button button2;
    private Button button3;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button4;
    private Button button5;
    private SerialPort com;
    private OpenFileDialog dakai;
    private OpenFileDialog da_kai_g;
    private FontDialog fontDialog1;
    private Panel panel2;
    private Button button17;
    private ProgressBar jdt;
    private Button button18;
    private Button button19;
    private Button button20;
    private Button button21;
    private Button button22;
    private Button button23;
    private TrackBar trackBar3;
    private Button button24;
    private Button button25;
    private Button button15;
    private Label label3;
    private Label label5;
    private Label label4;
    private Button button16;
    private Panel panel3;
    private Label label6;
    private Button button27;
    private Button button10;
    private Button button9;
    private TextBox textBox2;
    private TrackBar trackBar2;
    private Label label2;
    private RadioButton hei_bai;
    private RadioButton li_san;
    private RadioButton hui_du;
    private TextBox textBox3;
    private TrackBar trackBar1;
    private Label label1;
    private TextBox textBox1;
    private TrackBar trackBar4;
    private TextBox textBox5;
    private CheckBox checkBox2;
    private Button button11;
    private Button button12;
    private Button button13;
    private Button button14;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private TextBox textBox4;
    private Button button26;
    private System.Windows.Forms.Timer timer1;
    private Button button28;
    private Label label7;
    private Button button29;
    private Button button30;
    private Button button31;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Button button32;
    private System.Windows.Forms.Timer timer2;
    private Label label12;
    private System.Windows.Forms.Timer timer3;
    private Label label13;
    private GroupBox groupBox4;

    private void shu_xin()
    {
      if (this.an_xia)
        return;
      this.quan_bu_shua_xin();
    }

    private void shuxin()
    {
      this.BeginInvoke((Delegate) new Form1.MyInvoke(this.shu_xin));
    }

    public Form1()
    {
      this.InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.button1.Text == this.str2)
      {
        if (this.diao.lian_jie())
        {
          this.timer2.Enabled = true;
          this.panel3.Visible = true;
          this.button1.Text = this.str3;
          this.panel2.Refresh();
          this.diao.x = 0;
          this.diao.y = 0;
          this.dx = 0;
          this.dy = 0;
          this.x = 0;
          this.y = 0;
        }
        else
        {
          int num = (int) MessageBox.Show(this.str27);
        }
      }
      else
      {
        if (this.checkBox2.Checked)
          this.diao.guan_kuang();
        if (this.kai_shi)
        {
          this.button29_MouseDown((object) null, (MouseEventArgs) null);
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          this.button24_Click((object) null, (EventArgs) null);
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          Thread.Sleep(100);
          diao_ke_ji.处理事件();
          this.panel1.Location = new Point(25, 60);
          this.pan_yidong();
        }
        this.timer2.Enabled = false;
        this.com.Close();
        this.diao.lianjie = false;
        this.panel3.Visible = false;
        this.button1.Text = this.str2;
        this.panel2.Refresh();
      }
    }

    private void suo_fang2(Bitmap bb2, int da)
    {
      if (bb2.Width > bb2.Height)
      {
        int newW = bb2.Width + (this.trackBar3.Value - 1600);
        if (newW < 10)
          newW = 10;
        if (newW > da)
          newW = da;
        double num = (double) bb2.Width * 1.0 / (double) newW;
        int newH = (int) ((double) bb2.Height / num);
        this.diao.tu = tu_xiang.suofang(bb2, newW, newH);
      }
      else
      {
        int newH = bb2.Height + (this.trackBar3.Value - 1600);
        if (newH < 10)
          newH = 10;
        if (newH > da)
          newH = da;
        double num = (double) bb2.Height * 1.0 / (double) newH;
        int newW = (int) ((double) bb2.Width / num);
        this.diao.tu = tu_xiang.suofang(bb2, newW, newH);
      }
    }

    private void suo_fang(Bitmap bb2)
    {
      if (this.tu.Width - 1600 > this.tu.Height - 1520)
      {
        int newW = bb2.Width + (this.trackBar3.Value - 1600);
        if (newW < 200)
          newW = 200;
        if (newW > 1600)
          newW = 1600;
        double num = (double) bb2.Width * 1.0 / (double) newW;
        int newH = (int) ((double) bb2.Height / num);
        this.diao.tu = tu_xiang.suofang(bb2, newW, newH);
      }
      else
      {
        int newH = bb2.Height + (this.trackBar3.Value - 1600);
        if (newH < 200)
          newH = 200;
        if (newH > 1520)
          newH = 1520;
        double num = (double) bb2.Height * 1.0 / (double) newH;
        int newW = (int) ((double) bb2.Width / num);
        this.diao.tu = tu_xiang.suofang(bb2, newW, newH);
      }
      if (this.hei_bai.Checked)
      {
        this.diao.tu_pian = this.diao.hei_bai(this.trackBar2.Value);
        if (!this.fan_se)
          return;
        this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else if (this.li_san.Checked)
      {
        this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
        if (!this.fan_se)
          return;
        this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else
      {
        this.diao.tu_pian = this.diao.hui_du(this.trackBar2.Value);
        if (!this.fan_se)
          return;
        this.diao.tu_pian = tu_xiang.fanse_huidu(this.diao.tu_pian);
      }
    }

    private void dakai_chuli()
    {
      if (this.tu == null)
        return;
      this.suo_fang(this.tu);
    }

    private void da_kai()
    {
      Bitmap bitmap = new Bitmap(this.wen_jian_ming);
      this.tu = new Bitmap((Image) bitmap);
      bitmap.Dispose();
      this.diao.tu = this.tu;
      this.trackBar2.Value = 128;
      this.trackBar3.Value = this.trackBar3.Maximum / 2 + 10;
      if (this.hei_bai.Checked)
      {
        this.diao.tu_pian = this.diao.hei_bai(this.trackBar2.Value);
        if (this.fan_se)
          this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else if (this.li_san.Checked)
      {
        this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
        if (this.fan_se)
          this.diao.tu_pian = tu_xiang.fanse(this.diao.tu_pian);
      }
      else
        this.diao.tu_pian = this.diao.hui_du(this.trackBar2.Value);
      this.tu = tu_xiang.qu_bian_jie(this.diao.tu_pian);
      if (this.tu.Width <= 1600 && this.tu.Height <= 1520)
        return;
      if (this.tu.Width - 1600 > this.tu.Height - 1520)
        this.tu = tu_xiang.suofang(this.tu, 1600, (int) ((double) this.tu.Height / ((double) this.tu.Width / 1600.0)));
      else
        this.tu = tu_xiang.suofang(this.tu, (int) ((double) this.tu.Width / ((double) this.tu.Height / 1520.0)), 1520);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.textBox2.Visible)
      {
        this.textBox2.Visible = false;
        this.button9.Visible = false;
      }
      if (this.dakai.ShowDialog() != DialogResult.OK)
        return;
      this.wzms = false;
      this.wen_jian_ming = this.dakai.FileName;
      this.da_kai();
      this.gai_bian = true;
      this.shu_xin();
      this.pan_yidong();
    }

    private void hua_wen_zi()
    {
      float num = (float) this.panel1.Width * 3.2f / (float) this.tu.Width;
      Bitmap bitmap = new Bitmap((int) ((double) this.w_z.Width / (double) num), (int) ((double) this.w_z.Height / (double) num));
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage((Image) this.w_z, 0.0f, 0.0f, (float) this.w_z.Width / num, (float) this.w_z.Height / num);
      graphics.Dispose();
      for (int x = 0; x < bitmap.Width; ++x)
      {
        for (int y = 0; y < bitmap.Height; ++y)
        {
          if (bitmap.GetPixel(x, y).B < (byte) 1 && (int) ((double) this.wz_weizhi.X / (double) num + (double) x) < this.tu.Width && ((int) ((double) this.wz_weizhi.Y / (double) num + (double) y) < this.tu.Height && (int) ((double) this.wz_weizhi.X / (double) num + (double) x) > 0) && (int) ((double) this.wz_weizhi.Y / (double) num + (double) y) > 0)
            this.tu.SetPixel((int) ((double) this.wz_weizhi.X / (double) num + (double) x), (int) ((double) this.wz_weizhi.Y / (double) num + (double) y), Color.Black);
        }
      }
      this.w_z = (Bitmap) null;
    }

    private void quan_bu_shua_xin()
    {
      if (this.tu == null && !(this.textBox2.Text != ""))
        return;
      if (!this.kai_shi && this.gai_bian)
      {
        if (this.w_z != null)
        {
          if (this.wzms)
          {
            this.tu = new Bitmap(this.w_z.Width, this.w_z.Height);
            Graphics graphics = Graphics.FromImage((Image) this.tu);
            graphics.DrawImage((Image) this.w_z, 0, 0, this.w_z.Width, this.w_z.Height);
            graphics.Dispose();
            this.w_z = (Bitmap) null;
          }
          else
            this.hua_wen_zi();
        }
        this.dakai_chuli();
        this.gai_bian = false;
      }
      if (this.tu == null)
        return;
      tu_kuan_gao tuKuanGao = tu_xiang.shua_xin(this.panel1, this.diao.tu_pian, 0, 0, this.diao.tu_pian.Width, this.diao.tu_pian.Height, this.hui_du.Checked);
      this.diao.tu_pian = tuKuanGao.bb;
      this.hua_kg = new int[2]{ tuKuanGao.k, tuKuanGao.g };
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      this.quan_bu_shua_xin();
    }

    private void yu_yan()
    {
      this.button1.Text = this.str2;
      this.label3.Text = this.str1;
      this.Text = this.str28;
      this.button2.Text = this.str4;
      this.button5.Text = this.str5;
      this.button4.Text = this.str7;
      this.button29.Text = this.str8;
      this.button24.Text = this.str10;
      this.groupBox1.Text = this.str11;
      this.groupBox2.Text = this.str16;
      this.groupBox3.Text = this.str18;
      this.hei_bai.Text = this.str12;
      this.li_san.Text = this.str13;
      this.hui_du.Text = this.str14;
      this.label2.Text = this.str15;
      this.label1.Text = this.str17;
      this.button28.Text = this.str20;
      this.button30.Text = this.str19;
      this.button26.Text = this.str21;
      this.dakai.Filter = this.str34 + "|*.bmp;*.jpg;*.jpge;*.png";
      this.label13.Text = this.str36;
      this.groupBox4.Text = this.str37;
      this.trackBar3.Location = new Point(this.label3.Location.X + this.label3.Width, this.trackBar3.Location.Y);
      this.trackBar3.Width = this.label13.Location.X - (this.label3.Location.X + this.label3.Width);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.diao = new diao_ke_ji(this.com);
      this.panel1.Width = 20;
      this.panel1.Height = 20;
      this.diao.lian_jie();
      this.com.Close();
      this.diao.lianjie = false;
      this.panel3.Visible = false;
      this.button1.Text = this.str2;
      this.yu_yan();
      this.panel2.Refresh();
    }

    private void trackBar2_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.kai_shi)
        return;
      this.gai_bian = true;
      this.shu_xin();
      this.textBox3.Text = this.trackBar2.Value.ToString();
    }

    private void huaxian(Point[] zhixian)
    {
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu_pian);
      Point point = new Point();
      bool flag = false;
      for (int index = 0; index < zhixian.Length; ++index)
      {
        if (zhixian[index].X == 600 || zhixian[index].X == 601)
        {
          if (zhixian[index].X == 600)
            flag = true;
          if (zhixian[index].X == 601)
            flag = false;
        }
        else
        {
          if (flag)
            graphics.DrawLine(Pens.Blue, new Point(point.X, 500 - point.Y), new Point(zhixian[index].X, 500 - zhixian[index].Y));
          point = zhixian[index];
        }
      }
    }

    private void diaokexian(Point[] zhixian)
    {
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu_pian);
      Point point = new Point();
      this.diao.guan_ruo_guang();
      bool flag = this.hua2;
      if (flag)
      {
        point = new Point(zhixian[this.wei_zhi].X + this.dx, zhixian[this.wei_zhi].Y + this.dy);
        this.diao.gai_bian_F(0);
        this.diao.kai_deng();
        this.diao.gai_bian_F(this.trackBar1.Value);
      }
      else
        this.diao.gai_bian_F(0);
      for (int weiZhi = this.wei_zhi; weiZhi < zhixian.Length; ++weiZhi)
      {
        if (zhixian[weiZhi].X == 600 || zhixian[weiZhi].X == 601)
        {
          if (zhixian[weiZhi].X == 600)
          {
            flag = true;
            this.diao.kai_deng();
            this.diao.gai_bian_F(this.trackBar1.Value);
          }
          if (zhixian[weiZhi].X == 601)
          {
            flag = false;
            this.diao.guan_deng();
            this.diao.gai_bian_F(0);
          }
        }
        else
        {
          if (flag)
            graphics.DrawLine(Pens.Red, new Point(point.X, 500 - point.Y), new Point(zhixian[weiZhi].X, 500 - zhixian[weiZhi].Y));
          point = zhixian[weiZhi];
        }
      }
      this.button4.Refresh();
    }

    private void jie()
    {
      this.zhixian = g_dai_ma.jie_xi(this.wenben);
      this.huaxian(this.zhixian);
      this.shuxin();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (this.textBox2.Visible || this.da_kai_g.ShowDialog() != DialogResult.OK)
        return;
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu_pian);
      graphics.Clear(Color.White);
      graphics.Dispose();
      this.zhuang_tai = 2;
      this.textBox1.Text = "10";
      this.trackBar1.Maximum = 35;
      this.trackBar1.Value = 12;
      this.textBox1.Text = "12";
      this.dx = 0;
      this.dy = 0;
      this.wenben = File.ReadAllText(this.da_kai_g.FileName);
      new Thread(new ThreadStart(this.jie)).Start();
    }

    public bool diaoke2()
    {
      if (this.li_san.Checked)
        this.diao.li_san_mo_shi();
      else
        this.diao.fei_li_san_mo_shi();
      this.diao.fu_wei();
      this.diao.kai_feng();
      this.fen = true;
      this.diao.kai_shi((int) ((double) (this.panel1.Location.X - 25) * 3.2), (int) ((double) (this.panel1.Location.Y - 60) * 3.2));
      byte[] buffer = this.diao.tu_pian.Width % 8 <= 0 ? new byte[this.diao.tu_pian.Width / 8 + 9] : new byte[this.diao.tu_pian.Width / 8 + 10];
      byte[] numArray = new byte[8]
      {
        (byte) 128,
        (byte) 64,
        (byte) 32,
        (byte) 16,
        (byte) 8,
        (byte) 4,
        (byte) 2,
        (byte) 1
      };
      this.hei_dian_shu = this.diao.qu_hei_dian();
      this.timer3.Enabled = true;
      this.miao = 0;
      this.label12.Visible = true;
      for (int weiZhi = this.wei_zhi; weiZhi < this.diao.tu_pian.Height; ++weiZhi)
      {
        int num1 = 0;
        for (int index1 = 0; index1 < buffer.Length - 9; ++index1)
        {
          byte num2 = 0;
          for (int index2 = 0; index2 < 8; ++index2)
          {
            if (index1 * 8 + index2 < this.diao.tu_pian.Width && this.diao.tu_pian.GetPixel(index1 * 8 + index2, weiZhi).R == (byte) 0)
            {
              num2 |= numArray[index2];
              this.diao.tu_pian.SetPixel(index1 * 8 + index2, weiZhi, Color.Red);
            }
          }
          buffer[num1 + 9] = num2;
          ++num1;
        }
        buffer[0] = (byte) 9;
        buffer[1] = (byte) (buffer.Length >> 8);
        buffer[2] = (byte) buffer.Length;
        buffer[3] = (byte) (this.trackBar1.Value >> 8);
        buffer[4] = (byte) this.trackBar1.Value;
        buffer[5] = (byte) (this.trackBar4.Value >> 8);
        buffer[6] = (byte) this.trackBar4.Value;
        buffer[7] = (byte) (weiZhi >> 8);
        buffer[8] = (byte) weiZhi;
        this.diao.fanhui = false;
        bool flag = false;
        for (int index = 9; index < buffer.Length; ++index)
        {
          if (buffer[index] != (byte) 0)
          {
            flag = true;
            break;
          }
        }
        if (flag)
        {
          try
          {
            if (!this.com.IsOpen)
              return false;
            this.com.Write(buffer, 0, buffer.Length);
          }
          catch (Exception ex)
          {
            int num2 = (int) MessageBox.Show(ex.ToString());
          }
          int num3 = 0;
          while (!this.diao.fanhui)
          {
            ++num3;
            if (this.ting_zhi)
            {
              this.diao.ting_zhi();
              this.kai_shi = false;
              this.gai_bian = true;
              this.timer3.Enabled = false;
              this.label12.Visible = false;
              this.shu_xin();
              return false;
            }
            if (this.feng_shang)
            {
              if (this.fen)
                this.diao.kai_feng2();
              else
                this.diao.guan_feng2();
              this.feng_shang = false;
            }
            else if (this.zan_ting)
            {
              if (this.zan_ting2)
              {
                this.diao.zan_ting();
                this.timer3.Enabled = false;
              }
              else
              {
                this.diao.ji_xu();
                this.timer3.Enabled = true;
              }
              this.zan_ting = false;
            }
            diao_ke_ji.处理事件();
            Thread.Sleep(10);
          }
          this.gai_bian = true;
          this.shu_xin();
        }
      }
      if (!this.ting_zhi)
      {
        this.wei_zhi = 0;
        this.kai_shi = false;
        this.timer3.Enabled = false;
        this.timer3.Enabled = false;
        this.label12.Visible = false;
        this.diao.ting_zhi();
        this.kai_shi = false;
        this.gai_bian = true;
        this.timer3.Enabled = false;
        this.label12.Visible = false;
        this.shu_xin();
        this.quan_bu_shua_xin();
        int num = (int) MessageBox.Show(this.str26);
        return true;
      }
      this.timer3.Enabled = false;
      this.label12.Visible = false;
      this.diao.ting_zhi();
      this.kai_shi = false;
      this.gai_bian = true;
      this.timer3.Enabled = false;
      this.label12.Visible = false;
      this.shu_xin();
      return true;
    }

    public bool diaoke_hui()
    {
      this.diao.fei_li_san_mo_shi();
      this.diao.fu_wei();
      this.diao.kai_feng();
      this.fen = true;
      this.diao.kai_shi((int) ((double) (this.panel1.Location.X - 25) * 3.2), (int) ((double) (this.panel1.Location.Y - 60) * 3.2));
      byte[] buffer = new byte[this.diao.tu_pian.Width + 9];
      int width = this.diao.tu_pian.Width;
      int height = this.diao.tu_pian.Height;
      this.timer3.Enabled = true;
      this.miao = 0;
      this.label12.Visible = true;
      for (int y = 0; y < height; ++y)
      {
        for (int x = 0; x < width; ++x)
        {
          buffer[x + 9] = (byte) ((int) byte.MaxValue - (int) this.diao.tu_pian.GetPixel(x, y).R);
          this.diao.tu_pian.SetPixel(x, y, Color.FromArgb((int) this.diao.tu_pian.GetPixel(x, y).R, 0, 0));
        }
        bool flag = false;
        for (int index = 9; index < width; ++index)
        {
          if (buffer[index + 9] > (byte) 20)
          {
            flag = true;
            ++this.hei_dian_shu;
            break;
          }
        }
        if (flag)
        {
          buffer[0] = (byte) 19;
          buffer[1] = (byte) (buffer.Length >> 8);
          buffer[2] = (byte) buffer.Length;
          buffer[3] = (byte) (this.trackBar1.Value >> 8);
          buffer[4] = (byte) this.trackBar1.Value;
          buffer[5] = (byte) (this.trackBar4.Value >> 8);
          buffer[6] = (byte) this.trackBar4.Value;
          buffer[7] = (byte) (y >> 8);
          buffer[8] = (byte) y;
          this.diao.fanhui = false;
          try
          {
            if (!this.com.IsOpen)
              return false;
            this.com.Write(buffer, 0, buffer.Length);
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.ToString());
          }
          diao_ke_ji.处理事件();
          while (!this.diao.fanhui)
          {
            if (this.ting_zhi)
            {
              this.diao.ting_zhi();
              this.kai_shi = false;
              this.gai_bian = true;
              this.timer3.Enabled = false;
              this.label12.Visible = false;
              this.shu_xin();
              this.ting_zhi = false;
              return false;
            }
            if (this.feng_shang)
            {
              Thread.Sleep(500);
              if (this.fen)
                this.diao.kai_feng2();
              else
                this.diao.guan_feng2();
              this.feng_shang = false;
            }
            else if (this.zan_ting)
            {
              if (this.zan_ting2)
              {
                this.timer3.Enabled = false;
                this.diao.zan_ting();
              }
              else
              {
                this.timer3.Enabled = true;
                this.diao.ji_xu();
              }
              this.zan_ting = false;
            }
            diao_ke_ji.处理事件();
            Thread.Sleep(10);
          }
          this.gai_bian = true;
          this.shu_xin();
        }
      }
      if (!this.ting_zhi)
      {
        this.wei_zhi = 0;
        this.kai_shi = false;
        this.timer3.Enabled = false;
        this.timer3.Enabled = false;
        this.label12.Visible = false;
        this.diao.ting_zhi();
        this.kai_shi = false;
        this.gai_bian = true;
        this.timer3.Enabled = false;
        this.label12.Visible = false;
        this.shu_xin();
        this.quan_bu_shua_xin();
        int num = (int) MessageBox.Show(this.str26);
        return true;
      }
      this.timer3.Enabled = false;
      this.label12.Visible = false;
      this.diao.ting_zhi();
      this.kai_shi = false;
      this.gai_bian = true;
      this.timer3.Enabled = false;
      this.label12.Visible = false;
      this.shu_xin();
      return true;
    }

    private void button4_Click(object sender, EventArgs e)
    {
    }

    public Bitmap heibai(Bitmap bb)
    {
      Bitmap bitmap = new Bitmap((Image) bb);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num = ((int) destination[index] * 30 + (int) destination[index + 1] * 59 + (int) destination[index + 2] * 11) / 100 <= 150 ? 0 : (int) byte.MaxValue;
        source[index] = (byte) num;
        source[index + 1] = (byte) num;
        source[index + 2] = (byte) num;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    private void button5_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.textBox2.Visible)
      {
        this.button9.Visible = false;
        this.button10.Visible = false;
        this.textBox2.Text = this.textBox2.Text.Trim();
        if (this.textBox2.Text == "")
        {
          this.textBox2.Visible = false;
          this.button9.Visible = false;
          this.button10.Visible = false;
          this.button5.Text = this.str5;
        }
        else
        {
          this.textBox2.BorderStyle = BorderStyle.None;
          --this.textBox2.Width;
          this.textBox2.Location = new Point(this.textBox2.Location.X + 1, this.textBox2.Location.Y + 1);
          Thread.Sleep(10);
          diao_ke_ji.处理事件();
          Thread.Sleep(10);
          this.w_z = tu_xiang.jieping_控件((Control) this.textBox2);
          this.w_z = tu_xiang.suofang(this.w_z, (int) ((double) this.w_z.Width * 3.2), (int) ((double) this.w_z.Height * 3.2));
          this.w_z = this.heibai(this.w_z);
          this.wz_weizhi = new Point((int) ((double) (this.textBox2.Location.X - this.panel1.Location.X) * 3.2), (int) ((double) (this.textBox2.Location.Y - this.panel1.Location.Y) * 3.2));
          this.button5.Text = this.str5;
          this.textBox2.Visible = false;
          this.button9.Visible = false;
          this.button10.Visible = false;
          this.gai_bian = true;
          this.shu_xin();
          this.zhuang_tai = 3;
          this.dx = 0;
          this.dy = 0;
          this.wei_zhi = 0;
        }
      }
      else
      {
        this.zhuang_tai = 3;
        this.textBox2.Visible = true;
        this.button9.Visible = true;
        this.textBox2.Location = this.panel1.Location;
        this.textBox2.Focus();
        this.button10.Location = new Point(161, 126);
        this.textBox2.Size = new Size(150, 50);
        this.textBox2.BorderStyle = BorderStyle.FixedSingle;
        this.textBox2.Font = this.fontDialog1.Font;
        this.button9.Location = new Point(this.textBox2.Location.X + this.textBox2.Width, this.textBox2.Location.Y + this.textBox2.Height);
        this.button5.Text = this.str6;
        this.gai_bian = true;
        this.shu_xin();
      }
    }

    private void button10_MouseDown(object sender, MouseEventArgs e)
    {
      this.anxia = true;
      this.shu_x = e.X;
      this.shu_y = e.Y;
    }

    private void button10_MouseUp(object sender, MouseEventArgs e)
    {
      this.anxia = false;
    }

    private void button10_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.anxia)
        return;
      Point point = new Point();
      if (e.X - this.shu_x > 0)
      {
        if (this.textBox2.Location.X + this.textBox2.Size.Width < this.panel1.Width)
        {
          point.X = this.textBox2.Location.X + (e.X - this.shu_x);
          point.Y = this.textBox2.Location.Y;
          this.textBox2.Location = point;
          point.X = this.button10.Location.X + (e.X - this.shu_x);
          point.Y = this.button10.Location.Y;
          this.button10.Location = point;
          point.X = this.button9.Location.X + (e.X - this.shu_x);
          point.Y = this.button9.Location.Y;
          this.button9.Location = point;
        }
      }
      else if (this.textBox2.Location.X + (e.X - this.shu_x) > 0)
      {
        point.X = this.textBox2.Location.X + (e.X - this.shu_x);
        point.Y = this.textBox2.Location.Y;
        this.textBox2.Location = point;
        point.X = this.button10.Location.X + (e.X - this.shu_x);
        point.Y = this.button10.Location.Y;
        this.button10.Location = point;
        point.X = this.button9.Location.X + (e.X - this.shu_x);
        point.Y = this.button9.Location.Y;
        this.button9.Location = point;
      }
      if (e.Y - this.shu_y > 0)
      {
        if (this.textBox2.Location.Y + this.textBox2.Size.Height >= this.panel1.Height)
          return;
        point.X = this.textBox2.Location.X;
        point.Y = this.textBox2.Location.Y + (e.Y - this.shu_y);
        this.textBox2.Location = point;
        point.X = this.button10.Location.X;
        point.Y = this.button10.Location.Y + (e.Y - this.shu_y);
        this.button10.Location = point;
        point.X = this.button9.Location.X;
        point.Y = this.button9.Location.Y + (e.Y - this.shu_y);
        this.button9.Location = point;
      }
      else
      {
        if (this.textBox2.Location.Y + (e.Y - this.shu_y) <= 0)
          return;
        point.X = this.textBox2.Location.X;
        point.Y = this.textBox2.Location.Y + (e.Y - this.shu_y);
        this.textBox2.Location = point;
        point.X = this.button10.Location.X;
        point.Y = this.button10.Location.Y + (e.Y - this.shu_y);
        this.button10.Location = point;
        point.X = this.button9.Location.X;
        point.Y = this.button9.Location.Y + (e.Y - this.shu_y);
        this.button9.Location = point;
      }
    }

    private void button9_MouseDown(object sender, MouseEventArgs e)
    {
      this.anxia = true;
      this.shu_x = e.X;
      this.shu_y = e.Y;
    }

    private void button9_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.anxia)
        return;
      this.textBox2.Width = this.button9.Location.X - this.textBox2.Location.X;
      this.textBox2.Height = this.button9.Location.Y - this.textBox2.Location.Y;
      this.button9.Location = new Point(this.button9.Location.X + (e.X - this.shu_x), this.button9.Location.Y + (e.Y - this.shu_y));
    }

    private void button9_MouseUp(object sender, MouseEventArgs e)
    {
      this.anxia = false;
      if (this.textBox2.Width > 500)
      {
        this.textBox2.Width = 500;
        this.button9.Location = new Point(this.textBox2.Location.X + 500, this.button9.Location.Y);
      }
      if (this.textBox2.Height <= 500)
        return;
      this.textBox2.Height = 500;
      this.button9.Location = new Point(this.button9.Location.X, this.textBox2.Location.Y + 500);
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.diao.tu_pian == null)
        return;
      if (this.checkBox2.Checked)
      {
        this.checkBox2.Refresh();
        this.diao.kai_kuang(this.diao.tu_pian.Width, this.diao.tu_pian.Height);
      }
      else
        this.diao.guan_kuang();
    }

    private void button8_Click(object sender, EventArgs e)
    {
      int weiZhi = this.wei_zhi;
    }

    private void button7_Click(object sender, EventArgs e)
    {
      int weiZhi = this.wei_zhi;
      int kuanGao = this.diao.kuan_gao;
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {
    }

    private void trackBar1_MouseUp(object sender, MouseEventArgs e)
    {
      this.textBox1.Text = this.trackBar1.Value.ToString();
      if (!this.g_daima)
        return;
      this.diao.gai_bian_F(this.trackBar1.Value);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (this.textBox1.Text == "")
        return;
      try
      {
        if (Convert.ToInt32(this.textBox1.Text) < 1000)
        {
          this.trackBar1.Value = Convert.ToInt32(this.textBox1.Text);
        }
        else
        {
          this.textBox1.Text = "1000";
          this.trackBar1.Value = 1000;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
      this.trackBar2.Value = Convert.ToInt32(this.textBox3.Text);
    }

    private void button11_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y - (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)));
        this.pan_yidong();
      }
    }

    private void button12_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y + (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)));
        this.pan_yidong();
      }
    }

    private void button13_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X - (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)), this.panel1.Location.Y);
        this.pan_yidong();
      }
    }

    private void button14_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(this.panel1.Location.X + (int) ((double) Convert.ToInt16(this.textBox4.Text) * (5.0 / 16.0)), this.panel1.Location.Y);
        this.pan_yidong();
      }
    }

    private void button15_Click(object sender, EventArgs e)
    {
      this.diao.guan_ruo_guang();
      this.diao.dian_deng(this.trackBar1.Value);
    }

    private void button16_Click(object sender, EventArgs e)
    {
      this.diao.tuo_ji_da_yin();
    }

    private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void button17_Click(object sender, EventArgs e)
    {
      if (this.textBox2.Visible)
        return;
      if (this.zhuang_tai == 2)
        this.diao.duoji2(this.jdt, this.zhixian);
      else
        this.diao.duoji(this.jdt);
    }

    private void button20_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.fan_se = !this.fan_se;
      this.gai_bian = true;
      this.shu_xin();
    }

    private void button18_Click(object sender, EventArgs e)
    {
      this.suofang += 5;
      Graphics.FromImage((Image) this.diao.tu).DrawImage((Image) new Bitmap((Image) tu_xiang.suofang(this.tu, this.diao.kuan_gao + this.suofang, this.diao.kuan_gao + this.suofang)), 0, 0);
      this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
      this.shu_xin();
    }

    private void button19_Click(object sender, EventArgs e)
    {
      this.suofang -= 5;
      Bitmap bitmap = new Bitmap((Image) tu_xiang.suofang(this.tu, this.diao.kuan_gao + this.suofang, this.diao.kuan_gao + this.suofang));
      Graphics graphics = Graphics.FromImage((Image) this.diao.tu);
      graphics.Clear(Color.White);
      graphics.DrawImage((Image) bitmap, 0, 0);
      this.diao.tu_pian = this.diao.dou_dong(this.trackBar2.Value);
      this.shu_xin();
    }

    private void trackBar3_MouseUp(object sender, MouseEventArgs e)
    {
      this.gai_bian = true;
      this.quan_bu_shua_xin();
      if (this.checkBox2.Checked)
        this.diao.kai_kuang(this.diao.tu_pian.Width, this.diao.tu_pian.Height);
      this.pan_yidong();
    }

    private void button24_Click(object sender, EventArgs e)
    {
      if (this.button1.Text == this.str2)
        return;
      this.hei_dian_shu = 0;
      this.ting_zhi = true;
      this.kai_shi = false;
      this.wei_zhi = 0;
      this.hua2 = false;
      this.button29.Text = this.str8;
    }

    private void button21_Click(object sender, EventArgs e)
    {
      if (this.kai_shi || this.tu == null)
        return;
      this.tu.RotateFlip(RotateFlipType.RotateNoneFlipX);
      this.gai_bian = true;
      this.shu_xin();
    }

    private void button22_Click(object sender, EventArgs e)
    {
      if (this.kai_shi || this.tu == null)
        return;
      this.tu.RotateFlip(RotateFlipType.Rotate180FlipX);
      this.gai_bian = true;
      this.shu_xin();
    }

    private void button25_Click(object sender, EventArgs e)
    {
      if (this.kai_shi || this.tu == null)
        return;
      this.tu.RotateFlip(RotateFlipType.Rotate90FlipNone);
      this.gai_bian = true;
      this.panel1.Refresh();
      this.pan_yidong();
    }

    private void button23_Click(object sender, EventArgs e)
    {
      if (this.zhuang_tai == 2 || this.diao.tu_pian == null)
        return;
      this.gai_bian = true;
      if (this.ca)
      {
        this.ca = false;
        this.panel1.Cursor = Cursors.Cross;
      }
      else
      {
        this.ca = true;
        this.panel1.Cursor = Cursors.No;
      }
    }

    private void button15_Click_1(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.wenben = "";
      this.textBox2.Text = "";
      this.tu = (Bitmap) null;
      this.diao.tu = (Bitmap) null;
      this.diao.tu_pian = (Bitmap) null;
      this.wen_jian_ming = "";
      this.w_z = (Bitmap) null;
      if (this.checkBox2.Checked)
      {
        this.diao.guan_kuang();
        this.checkBox2.Checked = false;
      }
      this.wzms = true;
      this.panel1.Width = 20;
      this.panel1.Height = 20;
      this.panel1.Location = new Point(25, 60);
      this.pan_yidong();
      this.panel1.Refresh();
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      this.shubiao_x = e.X;
      this.shubiao_y = e.Y;
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      this.anxia3 = false;
      this.panel1.Refresh();
    }

    private void pictureBox1_LocationChanged(object sender, EventArgs e)
    {
    }

    private void button16_Click_1(object sender, EventArgs e)
    {
      this.diao.tuo_ji_da_yin();
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (this.kai_shi)
        return;
      if (this.textBox2.Visible)
      {
        this.textBox2.Visible = false;
        this.button9.Visible = false;
      }
      string str = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
      this.wzms = false;
      this.wen_jian_ming = str;
      this.da_kai();
      this.gai_bian = true;
      this.shu_xin();
      this.pan_yidong();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this.checkBox2.Checked)
        this.diao.guan_kuang();
      this.panel3.Visible = false;
      this.panel1.Width = 20;
      this.panel1.Height = 20;
      this.panel1.Location = new Point(25, 60);
      this.pan_yidong();
      this.timer2.Enabled = false;
      this.com.Close();
      this.diao.lianjie = false;
      this.panel2.Refresh();
      Process currentProcess = Process.GetCurrentProcess();
      foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
      {
        if (process.Id == currentProcess.Id)
          process.Kill();
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.guan = (Form) new guanyu();
      this.guan.Show();
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
    }

    private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (this.com.ReadByte() != 9)
        return;
      this.diao.fanhui = true;
    }

    private void com_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
    {
      try
      {
        this.com.Close();
        this.com.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(this.str30, ex.ToString());
        throw;
      }
    }

    private void button26_Click(object sender, EventArgs e)
    {
      this.diao.kai_deng();
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
      this.textBox4.Text = Form1.ToDBC(this.textBox4.Text);
      this.textBox4.Select(this.textBox4.Text.Length, 0);
    }

    public static string ToDBC(string input)
    {
      char[] charArray = input.ToCharArray();
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '　')
          charArray[index] = ' ';
        else if (charArray[index] > '\xFF00' && charArray[index] < '｟')
          charArray[index] = (char) ((uint) charArray[index] - 65248U);
      }
      return new string(charArray);
    }

    private void button27_Click(object sender, EventArgs e)
    {
      if (this.button1.Text == this.str2)
        return;
      if (this.kai_shi)
      {
        this.feng_shang = true;
        if (this.fen)
          this.fen = false;
        else
          this.fen = true;
      }
      else if (this.fen)
      {
        this.fen = false;
        this.diao.guan_feng();
      }
      else
      {
        this.fen = true;
        this.diao.kai_feng();
      }
    }

    private void hua_biao_shi()
    {
      Graphics graphics1 = this.CreateGraphics();
      graphics1.Clear(this.BackColor);
      if (this.tu != null)
      {
        Bitmap bitmap = new Bitmap(25, 15);
        Graphics graphics2 = Graphics.FromImage((Image) bitmap);
        Pen blue = Pens.Blue;
        int num1 = (int) ((double) this.diao.tu_pian.Width * 0.05);
        graphics2.Clear(this.BackColor);
        graphics2.DrawString(num1.ToString() + "MM", this.Font, Brushes.Blue, new PointF(0.0f, 0.0f));
        graphics1.DrawLine(blue, this.panel1.Location.X, this.panel1.Location.Y - 9, this.panel1.Location.X + this.hua_kg[0], this.panel1.Location.Y - 9);
        graphics1.DrawImage((Image) bitmap, this.panel1.Location.X + this.hua_kg[0] / 2 - bitmap.Width / 2, this.panel1.Location.Y - 15, bitmap.Width, bitmap.Height);
        int num2 = (int) ((double) this.diao.tu_pian.Height * 0.05);
        graphics2.Clear(this.BackColor);
        graphics2.DrawString(num2.ToString() + "MM", this.Font, Brushes.Blue, new PointF(0.0f, 0.0f));
        graphics1.DrawLine(blue, this.panel1.Location.X - 7, this.panel1.Location.Y, this.panel1.Location.X - 7, this.panel1.Location.Y + this.hua_kg[1]);
        bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
        graphics1.DrawImage((Image) bitmap, this.panel1.Location.X - 15, this.panel1.Location.Y + this.hua_kg[1] / 2 - bitmap.Height / 2, bitmap.Width, bitmap.Height);
        graphics1.DrawLine(blue, this.panel1.Location.X, this.panel1.Location.Y + this.hua_kg[1], this.panel1.Location.X - 15, this.panel1.Location.Y + this.hua_kg[1]);
        graphics1.DrawLine(blue, this.panel1.Location.X + this.hua_kg[0], this.panel1.Location.Y, this.panel1.Location.X + this.hua_kg[0], this.panel1.Location.Y - 15);
        graphics1.DrawLine(blue, this.panel1.Location.X, this.panel1.Location.Y, this.panel1.Location.X, this.panel1.Location.Y - 15);
        graphics1.DrawLine(blue, this.panel1.Location.X, this.panel1.Location.Y, this.panel1.Location.X - 15, this.panel1.Location.Y);
        graphics2.Dispose();
      }
      graphics1.Dispose();
    }

    private void hei_bai_CheckedChanged(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.gai_bian = true;
      this.trackBar2.Value = 128;
      this.textBox1.Text = "10";
      this.textBox3.Text = "128";
      if (this.wen_jian_ming == "")
        return;
      this.da_kai();
      this.gai_bian = true;
      this.panel1.Refresh();
    }

    private void li_san_CheckedChanged(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.gai_bian = true;
      this.trackBar2.Value = 128;
      this.textBox1.Text = "10";
      this.textBox3.Text = "128";
      if (this.textBox2.Visible || this.wen_jian_ming == "")
        return;
      this.da_kai();
      this.gai_bian = true;
      this.panel1.Refresh();
    }

    private void hui_du_CheckedChanged(object sender, EventArgs e)
    {
      if (this.kai_shi || this.textBox2.Visible)
        return;
      this.trackBar2.Value = 128;
      this.gai_bian = true;
      this.textBox1.Text = "10";
      this.textBox3.Text = "128";
      if (this.wen_jian_ming == "")
        return;
      this.da_kai();
      this.gai_bian = true;
      this.panel1.Refresh();
    }

    private void trackBar4_Scroll(object sender, EventArgs e)
    {
      this.textBox5.Text = this.trackBar4.Value.ToString();
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
      this.trackBar4.Value = Convert.ToInt32(this.textBox5.Text);
    }

    private void button4_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void button4_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.button1.Text == this.str2)
      {
        int num1 = (int) MessageBox.Show(this.str23);
      }
      else if (this.tu == null && this.textBox2.Text == "")
      {
        int num2 = (int) MessageBox.Show(this.str24);
      }
      else if (this.kai_shi)
      {
        int num3 = (int) MessageBox.Show(this.str25);
      }
      else
      {
        if (this.textBox2.Visible)
          this.button5_Click((object) null, new EventArgs());
        if (this.checkBox2.Checked)
        {
          int num4 = (int) MessageBox.Show(this.str35);
        }
        else
        {
          this.kai_shi = true;
          this.ting_zhi = false;
          if (this.hui_du.Checked)
            this.diaoke_hui();
          else
            this.diaoke2();
        }
      }
    }

    private void button26_Click_1(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else
      {
        if (this.textBox2.Visible)
        {
          int num3 = (int) MessageBox.Show(this.str29);
        }
        this.diao.dao_yuandian();
        this.panel1.Location = new Point(25, 60);
        this.x = 0;
        this.y = 0;
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (this.kai_shi)
        return;
      this.hua_biao_shi();
    }

    private void button28_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.tu == null && this.textBox2.Text == "")
      {
        int num3 = (int) MessageBox.Show(this.str24);
      }
      else if (this.textBox2.Visible)
      {
        int num4 = (int) MessageBox.Show(this.str29);
      }
      else if (!this.checkBox2.Checked)
        this.checkBox2.Checked = true;
      else
        this.checkBox2.Checked = false;
    }

    private void li_san_MouseDown(object sender, MouseEventArgs e)
    {
      int num = this.textBox2.Visible ? 1 : 0;
    }

    private void button29_MouseDown(object sender, MouseEventArgs e)
    {
      if (!this.kai_shi)
        return;
      this.zan_ting = true;
      if (this.button29.Text == this.str8)
      {
        this.zan_ting2 = true;
        this.button29.Text = this.str9;
      }
      else
      {
        this.zan_ting2 = false;
        this.button29.Text = this.str8;
      }
    }

    private void button29_Click(object sender, EventArgs e)
    {
    }

    private void button30_Click(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        int num1 = (int) MessageBox.Show(this.str25);
      }
      else if (this.button1.Text == this.str2)
      {
        int num2 = (int) MessageBox.Show(this.str23);
      }
      else if (this.textBox2.Visible)
      {
        int num3 = (int) MessageBox.Show(this.str29);
      }
      else
      {
        this.panel1.Location = new Point(275, 310);
        this.pan_yidong();
      }
    }

    private void button31_Paint(object sender, PaintEventArgs e)
    {
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      if (this.textBox2.Visible)
        return;
      this.quan_bu_shua_xin();
    }

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
      this.an_xia = true;
      this.yi_dian = new Point(e.X, e.Y);
    }

    private void pan_yidong()
    {
      if (this.panel1.Location.X < 25)
        this.panel1.Location = new Point(25, this.panel1.Location.Y);
      if (this.panel1.Location.Y < 60)
        this.panel1.Location = new Point(this.panel1.Location.X, 60);
      if (this.panel1.Location.X + this.panel1.Width > 525)
        this.panel1.Location = new Point(525 - this.panel1.Width, this.panel1.Location.Y);
      if (this.panel1.Location.Y + this.panel1.Height > 560)
        this.panel1.Location = new Point(this.panel1.Location.X, 560 - this.panel1.Height);
      if (!this.diao.lianjie)
        return;
      this.diao.yidong((int) ((double) (this.panel1.Location.X - 25 - this.x) * 3.2), (int) ((double) (this.panel1.Location.Y - 60 - this.y) * 3.2), new PictureBox(), false);
      this.x = this.panel1.Location.X - 25;
      this.y = this.panel1.Location.Y - 60;
    }

    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
      this.an_xia = false;
      this.pan_yidong();
    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.an_xia)
        return;
      if (this.button1.Text == this.str2)
      {
        int num = (int) MessageBox.Show(this.str23);
        this.an_xia = false;
      }
      else if (this.kai_shi)
      {
        int num = (int) MessageBox.Show(this.str25);
        this.an_xia = false;
      }
      else
        this.panel1.Location = new Point(this.panel1.Location.X + (e.X - this.yi_dian.X), this.panel1.Location.Y + (e.Y - this.yi_dian.Y));
    }

    private void button31_Click(object sender, EventArgs e)
    {
      this.heibai(tu_xiang.jieping_控件((Control) this.button1));
    }

    private void button32_Click(object sender, EventArgs e)
    {
      if (this.fontDialog1.ShowDialog() != DialogResult.OK)
        return;
      this.textBox2.Font = this.fontDialog1.Font;
      this.ziti = this.fontDialog1.Font;
    }

    private void textBox2_MouseDown(object sender, MouseEventArgs e)
    {
      this.bjk_anxia = true;
      this.bjk_x = e.X;
      this.bjk_y = e.Y;
    }

    private void textBox2_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.bjk_anxia)
        return;
      this.textBox2.Location = new Point(this.textBox2.Location.X + (e.X - this.bjk_x), this.textBox2.Location.Y + (e.Y - this.bjk_y));
    }

    private void textBox2_MouseUp(object sender, MouseEventArgs e)
    {
      this.bjk_anxia = false;
      if (this.textBox2.Location.X < 25)
        this.textBox2.Location = new Point(25, this.textBox2.Location.Y);
      if (this.textBox2.Location.X + this.textBox2.Width > 525)
        this.textBox2.Location = new Point(525 - this.textBox2.Width, this.textBox2.Location.Y);
      if (this.textBox2.Location.Y < 60)
        this.textBox2.Location = new Point(this.textBox2.Location.X, 60);
      if (this.textBox2.Location.Y + this.textBox2.Height <= 560)
        return;
      this.textBox2.Location = new Point(this.textBox2.Location.X, 560 - this.textBox2.Height);
    }

    private void textBox2_LocationChanged(object sender, EventArgs e)
    {
      this.button9.Location = new Point(this.textBox2.Location.X + this.textBox2.Width, this.textBox2.Location.Y + this.textBox2.Height);
    }

    [DllImport("kernel32.dll")]
    private static extern uint SetThreadExecutionState(Form1.ExecutionFlag flags);

    public static void PreventSleep(bool includeDisplay = false)
    {
      if (includeDisplay)
      {
        int num1 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System | Form1.ExecutionFlag.Display | Form1.ExecutionFlag.Continus);
      }
      else
      {
        int num2 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System | Form1.ExecutionFlag.Continus);
      }
    }

    public static void ResotreSleep()
    {
      int num = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.Continus);
    }

    public static void ResetSleepTimer(bool includeDisplay = false)
    {
      if (includeDisplay)
      {
        int num1 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System | Form1.ExecutionFlag.Display);
      }
      else
      {
        int num2 = (int) Form1.SetThreadExecutionState(Form1.ExecutionFlag.System);
      }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      if (this.kai_shi)
      {
        ++this.miao60;
        if (this.miao60 > 100)
        {
          this.miao60 = 0;
          Form1.ResetSleepTimer(true);
        }
      }
      if (!this.diao.lianjie)
        return;
      try
      {
        if (this.com.IsOpen)
          return;
        this.com.Close();
        this.diao.lianjie = false;
        this.panel3.Visible = false;
        this.button1.Text = this.str2;
        if (this.kai_shi)
        {
          this.hei_dian_shu = 0;
          this.ting_zhi = true;
          this.zan_ting = false;
          this.zan_ting2 = false;
          this.kai_shi = false;
          this.wei_zhi = 0;
          this.hua2 = false;
          this.button29.Text = this.str8;
        }
        this.panel2.Refresh();
        int num = (int) MessageBox.Show(this.str22);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    private void timer3_Tick(object sender, EventArgs e)
    {
      ++this.miao;
      this.label12.Text = this.str31 + (this.miao / 60).ToString() + this.str32 + (this.miao % 60).ToString() + this.str33;
      this.label12.Refresh();
    }

    private void label7_Click(object sender, EventArgs e)
    {
    }

    private void groupBox3_Enter(object sender, EventArgs e)
    {
    }

    private void label13_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.panel1 = new Panel();
      this.button10 = new Button();
      this.button9 = new Button();
      this.textBox2 = new TextBox();
      this.button18 = new Button();
      this.button19 = new Button();
      this.button1 = new Button();
      this.checkBox1 = new CheckBox();
      this.button2 = new Button();
      this.button3 = new Button();
      this.button6 = new Button();
      this.button7 = new Button();
      this.button8 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.com = new SerialPort(this.components);
      this.dakai = new OpenFileDialog();
      this.da_kai_g = new OpenFileDialog();
      this.fontDialog1 = new FontDialog();
      this.panel2 = new Panel();
      this.panel3 = new Panel();
      this.button17 = new Button();
      this.jdt = new ProgressBar();
      this.button20 = new Button();
      this.button21 = new Button();
      this.button22 = new Button();
      this.button23 = new Button();
      this.trackBar3 = new TrackBar();
      this.button24 = new Button();
      this.button25 = new Button();
      this.button15 = new Button();
      this.label3 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.button16 = new Button();
      this.label6 = new Label();
      this.button27 = new Button();
      this.trackBar2 = new TrackBar();
      this.label2 = new Label();
      this.hei_bai = new RadioButton();
      this.li_san = new RadioButton();
      this.hui_du = new RadioButton();
      this.textBox3 = new TextBox();
      this.trackBar1 = new TrackBar();
      this.label1 = new Label();
      this.textBox1 = new TextBox();
      this.trackBar4 = new TrackBar();
      this.textBox5 = new TextBox();
      this.checkBox2 = new CheckBox();
      this.button11 = new Button();
      this.button12 = new Button();
      this.button13 = new Button();
      this.button14 = new Button();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.groupBox3 = new GroupBox();
      this.button30 = new Button();
      this.button28 = new Button();
      this.button26 = new Button();
      this.label13 = new Label();
      this.textBox4 = new TextBox();
      this.label7 = new Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button29 = new Button();
      this.button31 = new Button();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.button32 = new Button();
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.label12 = new Label();
      this.timer3 = new System.Windows.Forms.Timer(this.components);
      this.groupBox4 = new GroupBox();
      this.panel2.SuspendLayout();
      this.trackBar3.BeginInit();
      this.trackBar2.BeginInit();
      this.trackBar1.BeginInit();
      this.trackBar4.BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      this.panel1.BackColor = Color.White;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Cursor = Cursors.SizeAll;
      this.panel1.Location = new Point(25, 60);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(247, 176);
      this.panel1.TabIndex = 1;
      this.panel1.TabStop = true;
      this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
      this.panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      this.panel1.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      this.panel1.MouseUp += new MouseEventHandler(this.panel1_MouseUp);
      this.button10.BackColor = Color.Transparent;
      this.button10.Cursor = Cursors.SizeAll;
      this.button10.DialogResult = DialogResult.Cancel;
      this.button10.Location = new Point(438, 187);
      this.button10.Name = "button10";
      this.button10.Size = new Size(17, 17);
      this.button10.TabIndex = 2;
      this.button10.UseVisualStyleBackColor = false;
      this.button10.Visible = false;
      this.button10.MouseDown += new MouseEventHandler(this.button10_MouseDown);
      this.button10.MouseMove += new MouseEventHandler(this.button10_MouseMove);
      this.button10.MouseUp += new MouseEventHandler(this.button10_MouseUp);
      this.button9.BackColor = Color.Transparent;
      this.button9.Cursor = Cursors.SizeNWSE;
      this.button9.Location = new Point(453, 203);
      this.button9.Name = "button9";
      this.button9.Size = new Size(17, 17);
      this.button9.TabIndex = 1;
      this.button9.UseVisualStyleBackColor = false;
      this.button9.Visible = false;
      this.button9.MouseDown += new MouseEventHandler(this.button9_MouseDown);
      this.button9.MouseMove += new MouseEventHandler(this.button9_MouseMove);
      this.button9.MouseUp += new MouseEventHandler(this.button9_MouseUp);
      this.textBox2.BorderStyle = BorderStyle.FixedSingle;
      this.textBox2.Cursor = Cursors.SizeAll;
      this.textBox2.Font = new Font("宋体", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.textBox2.Location = new Point(278, 61);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(177, 143);
      this.textBox2.TabIndex = 0;
      this.textBox2.Visible = false;
      this.textBox2.LocationChanged += new EventHandler(this.textBox2_LocationChanged);
      this.textBox2.MouseDown += new MouseEventHandler(this.textBox2_MouseDown);
      this.textBox2.MouseMove += new MouseEventHandler(this.textBox2_MouseMove);
      this.textBox2.MouseUp += new MouseEventHandler(this.textBox2_MouseUp);
      this.button18.Location = new Point(966, 214);
      this.button18.Name = "button18";
      this.button18.Size = new Size(35, 35);
      this.button18.TabIndex = 30;
      this.button18.UseVisualStyleBackColor = true;
      this.button18.Visible = false;
      this.button18.Click += new EventHandler(this.button18_Click);
      this.button19.Location = new Point(949, 215);
      this.button19.Name = "button19";
      this.button19.Size = new Size(35, 35);
      this.button19.TabIndex = 31;
      this.button19.UseVisualStyleBackColor = true;
      this.button19.Visible = false;
      this.button19.Click += new EventHandler(this.button19_Click);
      this.button1.BackColor = Color.Transparent;
      this.button1.DialogResult = DialogResult.Cancel;
      this.button1.ForeColor = Color.Blue;
      this.button1.Location = new Point(532, 10);
      this.button1.Name = "button1";
      this.button1.Size = new Size(107, 41);
      this.button1.TabIndex = 1;
      this.button1.Text = "設備接続";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(949, 7);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(66, 16);
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "250*250";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.Visible = false;
      this.button2.BackColor = Color.Transparent;
      this.button2.Location = new Point(531, 60);
      this.button2.Name = "button2";
      this.button2.Size = new Size(107, 33);
      this.button2.TabIndex = 3;
      this.button2.Text = "絵図導入";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.BackColor = Color.Transparent;
      this.button3.ForeColor = Color.Red;
      this.button3.Location = new Point(915, -2);
      this.button3.Name = "button3";
      this.button3.Size = new Size(94, 30);
      this.button3.TabIndex = 4;
      this.button3.Text = "关于";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button6.BackColor = Color.Transparent;
      this.button6.Location = new Point(917, 73);
      this.button6.Name = "button6";
      this.button6.Size = new Size(107, 30);
      this.button6.TabIndex = 6;
      this.button6.Text = "打开G代码";
      this.button6.UseVisualStyleBackColor = false;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.button7.BackColor = Color.Transparent;
      this.button7.Location = new Point(994, 105);
      this.button7.Name = "button7";
      this.button7.Size = new Size(107, 30);
      this.button7.TabIndex = 11;
      this.button7.Text = "快进>>";
      this.button7.UseVisualStyleBackColor = false;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button8.BackColor = Color.Transparent;
      this.button8.Location = new Point(917, 109);
      this.button8.Name = "button8";
      this.button8.Size = new Size(107, 30);
      this.button8.TabIndex = 10;
      this.button8.Text = "<<快退";
      this.button8.UseVisualStyleBackColor = false;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button4.BackColor = Color.Transparent;
      this.button4.ForeColor = Color.Red;
      this.button4.Location = new Point(531, 99);
      this.button4.Name = "button4";
      this.button4.Size = new Size(71, 36);
      this.button4.TabIndex = 12;
      this.button4.Text = "スタート";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button4.MouseDown += new MouseEventHandler(this.button4_MouseDown);
      this.button4.MouseUp += new MouseEventHandler(this.button4_MouseUp);
      this.button5.BackColor = Color.Transparent;
      this.button5.Location = new Point(654, 60);
      this.button5.Name = "button5";
      this.button5.Size = new Size(107, 33);
      this.button5.TabIndex = 13;
      this.button5.Text = "文字編集";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.com.ErrorReceived += new SerialErrorReceivedEventHandler(this.com_ErrorReceived);
      this.com.DataReceived += new SerialDataReceivedEventHandler(this.com_DataReceived);
      this.dakai.FileName = "openFileDialog1";
      this.dakai.Filter = "ビットマップファイル|*.bmp;*.jpg;*.jpge;*.png;";
      this.da_kai_g.FileName = "openFileDialog1";
      this.da_kai_g.Filter = "刀路文件|*.NC|所有文件|*.*";
      this.fontDialog1.Font = new Font("宋体", 24f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.panel2.BackColor = Color.Transparent;
      this.panel2.BackgroundImage = (Image) componentResourceManager.GetObject("panel2.BackgroundImage");
      this.panel2.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel2.Controls.Add((Control) this.panel3);
      this.panel2.Location = new Point(692, 14);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(32, 32);
      this.panel2.TabIndex = 23;
      this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
      this.panel3.BackColor = Color.Transparent;
      this.panel3.BackgroundImage = (Image) componentResourceManager.GetObject("panel3.BackgroundImage");
      this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
      this.panel3.Location = new Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(32, 32);
      this.panel3.TabIndex = 44;
      this.panel3.Visible = false;
      this.button17.BackColor = Color.Transparent;
      this.button17.Location = new Point(927, 391);
      this.button17.Name = "button17";
      this.button17.Size = new Size(215, 38);
      this.button17.TabIndex = 28;
      this.button17.Text = "发送脱机数据";
      this.button17.UseVisualStyleBackColor = false;
      this.button17.Click += new EventHandler(this.button17_Click);
      this.jdt.Location = new Point(928, 431);
      this.jdt.Name = "jdt";
      this.jdt.Size = new Size(213, 10);
      this.jdt.TabIndex = 29;
      this.jdt.Visible = false;
      this.button20.BackColor = Color.Transparent;
      this.button20.Image = (Image) componentResourceManager.GetObject("button20.Image");
      this.button20.Location = new Point(364, 12);
      this.button20.Name = "button20";
      this.button20.Size = new Size(35, 35);
      this.button20.TabIndex = 32;
      this.button20.UseVisualStyleBackColor = false;
      this.button20.Click += new EventHandler(this.button20_Click);
      this.button21.BackColor = Color.Transparent;
      this.button21.Image = (Image) componentResourceManager.GetObject("button21.Image");
      this.button21.Location = new Point(241, 11);
      this.button21.Name = "button21";
      this.button21.Size = new Size(35, 35);
      this.button21.TabIndex = 33;
      this.button21.UseVisualStyleBackColor = false;
      this.button21.Click += new EventHandler(this.button21_Click);
      this.button22.BackColor = Color.Transparent;
      this.button22.Image = (Image) componentResourceManager.GetObject("button22.Image");
      this.button22.Location = new Point(282, 12);
      this.button22.Name = "button22";
      this.button22.Size = new Size(35, 35);
      this.button22.TabIndex = 34;
      this.button22.UseVisualStyleBackColor = false;
      this.button22.Click += new EventHandler(this.button22_Click);
      this.button23.BackColor = Color.Transparent;
      this.button23.Image = (Image) componentResourceManager.GetObject("button23.Image");
      this.button23.Location = new Point(928, 29);
      this.button23.Name = "button23";
      this.button23.Size = new Size(35, 35);
      this.button23.TabIndex = 35;
      this.button23.UseVisualStyleBackColor = false;
      this.button23.Click += new EventHandler(this.button23_Click);
      this.trackBar3.AutoSize = false;
      this.trackBar3.Location = new Point(34, 11);
      this.trackBar3.Maximum = 3200;
      this.trackBar3.Name = "trackBar3";
      this.trackBar3.Size = new Size(201, 31);
      this.trackBar3.TabIndex = 36;
      this.trackBar3.Value = 1650;
      this.trackBar3.MouseUp += new MouseEventHandler(this.trackBar3_MouseUp);
      this.button24.BackColor = Color.Transparent;
      this.button24.Location = new Point(689, 99);
      this.button24.Name = "button24";
      this.button24.Size = new Size(71, 36);
      this.button24.TabIndex = 37;
      this.button24.Text = "停止";
      this.button24.UseVisualStyleBackColor = false;
      this.button24.Click += new EventHandler(this.button24_Click);
      this.button25.BackColor = Color.Transparent;
      this.button25.Image = (Image) componentResourceManager.GetObject("button25.Image");
      this.button25.Location = new Point(323, 12);
      this.button25.Name = "button25";
      this.button25.Size = new Size(35, 35);
      this.button25.TabIndex = 31;
      this.button25.UseVisualStyleBackColor = false;
      this.button25.Click += new EventHandler(this.button25_Click);
      this.button15.BackColor = Color.Transparent;
      this.button15.Image = (Image) componentResourceManager.GetObject("button15.Image");
      this.button15.Location = new Point(446, 12);
      this.button15.Name = "button15";
      this.button15.Size = new Size(35, 35);
      this.button15.TabIndex = 31;
      this.button15.UseVisualStyleBackColor = false;
      this.button15.Click += new EventHandler(this.button15_Click_1);
      this.label3.AutoSize = true;
      this.label3.FlatStyle = FlatStyle.Popup;
      this.label3.Font = new Font("宋体", 13f);
      this.label3.Location = new Point(3, 15);
      this.label3.Name = "label3";
      this.label3.Size = new Size(44, 18);
      this.label3.TabIndex = 32;
      this.label3.Text = "缩放";
      this.label5.BorderStyle = BorderStyle.FixedSingle;
      this.label5.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label5.ForeColor = Color.Blue;
      this.label5.Location = new Point(978, 513);
      this.label5.Name = "label5";
      this.label5.Size = new Size(92, 31);
      this.label5.TabIndex = 41;
      this.label5.Text = "Y：";
      this.label4.BorderStyle = BorderStyle.FixedSingle;
      this.label4.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.label4.ForeColor = Color.Blue;
      this.label4.Location = new Point(917, 483);
      this.label4.Name = "label4";
      this.label4.Size = new Size(92, 31);
      this.label4.TabIndex = 42;
      this.label4.Text = "X：";
      this.button16.BackColor = Color.Transparent;
      this.button16.ForeColor = Color.Red;
      this.button16.Location = new Point(928, 145);
      this.button16.Name = "button16";
      this.button16.Size = new Size(53, 30);
      this.button16.TabIndex = 43;
      this.button16.Text = "开始";
      this.button16.UseVisualStyleBackColor = false;
      this.button16.Visible = false;
      this.button16.Click += new EventHandler(this.button16_Click_1);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(919, 293);
      this.label6.Name = "label6";
      this.label6.Size = new Size(65, 12);
      this.label6.TabIndex = 47;
      this.label6.Text = "激光功率：";
      this.button27.BackColor = Color.Transparent;
      this.button27.BackgroundImageLayout = ImageLayout.Stretch;
      this.button27.Image = (Image) componentResourceManager.GetObject("button27.Image");
      this.button27.Location = new Point(405, 12);
      this.button27.Name = "button27";
      this.button27.Size = new Size(35, 35);
      this.button27.TabIndex = 52;
      this.button27.UseVisualStyleBackColor = false;
      this.button27.Click += new EventHandler(this.button27_Click);
      this.trackBar2.Location = new Point(11, 83);
      this.trackBar2.Maximum = 253;
      this.trackBar2.Name = "trackBar2";
      this.trackBar2.Size = new Size(190, 45);
      this.trackBar2.TabIndex = 16;
      this.trackBar2.Value = 128;
      this.trackBar2.MouseUp += new MouseEventHandler(this.trackBar2_MouseUp);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(834, 248);
      this.label2.Name = "label2";
      this.label2.Size = new Size(65, 12);
      this.label2.TabIndex = 17;
      this.label2.Text = "絵図調整：";
      this.label2.Visible = false;
      this.hei_bai.AutoSize = true;
      this.hei_bai.Checked = true;
      this.hei_bai.Location = new Point(49, 20);
      this.hei_bai.Name = "hei_bai";
      this.hei_bai.Size = new Size(47, 16);
      this.hei_bai.TabIndex = 49;
      this.hei_bai.TabStop = true;
      this.hei_bai.Text = "黒白";
      this.hei_bai.UseVisualStyleBackColor = true;
      this.hei_bai.CheckedChanged += new EventHandler(this.hei_bai_CheckedChanged);
      this.li_san.AutoSize = true;
      this.li_san.Location = new Point(49, 41);
      this.li_san.Name = "li_san";
      this.li_san.Size = new Size(47, 16);
      this.li_san.TabIndex = 50;
      this.li_san.Text = "离散";
      this.li_san.UseVisualStyleBackColor = true;
      this.li_san.CheckedChanged += new EventHandler(this.li_san_CheckedChanged);
      this.li_san.MouseDown += new MouseEventHandler(this.li_san_MouseDown);
      this.hui_du.AutoSize = true;
      this.hui_du.Location = new Point(49, 65);
      this.hui_du.Name = "hui_du";
      this.hui_du.Size = new Size(107, 16);
      this.hui_du.TabIndex = 51;
      this.hui_du.Text = "グレースケール";
      this.hui_du.UseVisualStyleBackColor = true;
      this.hui_du.CheckedChanged += new EventHandler(this.hui_du_CheckedChanged);
      this.textBox3.BackColor = Color.Gainsboro;
      this.textBox3.BorderStyle = BorderStyle.FixedSingle;
      this.textBox3.Location = new Point(197, 88);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(33, 21);
      this.textBox3.TabIndex = 18;
      this.textBox3.Text = "128";
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox3.TextChanged += new EventHandler(this.textBox3_TextChanged);
      this.trackBar1.Location = new Point(6, 20);
      this.trackBar1.Maximum = 200;
      this.trackBar1.Minimum = 1;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new Size(191, 45);
      this.trackBar1.TabIndex = 8;
      this.trackBar1.Value = 10;
      this.trackBar1.MouseUp += new MouseEventHandler(this.trackBar1_MouseUp);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(834, 375);
      this.label1.Name = "label1";
      this.label1.Size = new Size(101, 12);
      this.label1.TabIndex = 9;
      this.label1.Text = "彫刻の深さ調整：";
      this.label1.Visible = false;
      this.textBox1.BackColor = Color.Gainsboro;
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Location = new Point(195, 23);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(33, 21);
      this.textBox1.TabIndex = 14;
      this.textBox1.Text = "10";
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.trackBar4.Location = new Point(12, 15);
      this.trackBar4.Maximum = 1000;
      this.trackBar4.Name = "trackBar4";
      this.trackBar4.Size = new Size(175, 45);
      this.trackBar4.TabIndex = 46;
      this.trackBar4.Value = 1000;
      this.trackBar4.Scroll += new EventHandler(this.trackBar4_Scroll);
      this.textBox5.BackColor = Color.Gainsboro;
      this.textBox5.BorderStyle = BorderStyle.FixedSingle;
      this.textBox5.Location = new Point(193, 15);
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      this.textBox5.Size = new Size(35, 21);
      this.textBox5.TabIndex = 48;
      this.textBox5.Text = "1000";
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.textBox5.TextChanged += new EventHandler(this.textBox5_TextChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(831, 408);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(60, 16);
      this.checkBox2.TabIndex = 15;
      this.checkBox2.Text = "框定位";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.Visible = false;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.button11.BackColor = Color.Transparent;
      this.button11.DialogResult = DialogResult.Cancel;
      this.button11.Location = new Point(84, 80);
      this.button11.Name = "button11";
      this.button11.Size = new Size(67, 35);
      this.button11.TabIndex = 19;
      this.button11.Text = "↑";
      this.button11.UseVisualStyleBackColor = false;
      this.button11.Click += new EventHandler(this.button11_Click);
      this.button12.BackColor = Color.Transparent;
      this.button12.Location = new Point(84, 159);
      this.button12.Name = "button12";
      this.button12.Size = new Size(67, 35);
      this.button12.TabIndex = 20;
      this.button12.Text = "↓";
      this.button12.UseVisualStyleBackColor = false;
      this.button12.Click += new EventHandler(this.button12_Click);
      this.button13.BackColor = Color.Transparent;
      this.button13.Location = new Point(11, 119);
      this.button13.Name = "button13";
      this.button13.Size = new Size(67, 35);
      this.button13.TabIndex = 21;
      this.button13.Text = "←";
      this.button13.UseVisualStyleBackColor = false;
      this.button13.Click += new EventHandler(this.button13_Click);
      this.button14.BackColor = Color.Transparent;
      this.button14.Location = new Point(157, 119);
      this.button14.Name = "button14";
      this.button14.Size = new Size(67, 35);
      this.button14.TabIndex = 22;
      this.button14.Text = "→";
      this.button14.UseVisualStyleBackColor = false;
      this.button14.Click += new EventHandler(this.button14_Click);
      this.groupBox1.Controls.Add((Control) this.textBox3);
      this.groupBox1.Controls.Add((Control) this.hui_du);
      this.groupBox1.Controls.Add((Control) this.li_san);
      this.groupBox1.Controls.Add((Control) this.hei_bai);
      this.groupBox1.Controls.Add((Control) this.trackBar2);
      this.groupBox1.Location = new Point(532, 141);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(231, 118);
      this.groupBox1.TabIndex = 53;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "彫刻スタイル選択";
      this.groupBox2.Controls.Add((Control) this.textBox1);
      this.groupBox2.Controls.Add((Control) this.trackBar1);
      this.groupBox2.Location = new Point(535, 271);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(228, 50);
      this.groupBox2.TabIndex = 54;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "レーザー彫刻パラメータ調整";
      this.groupBox3.Controls.Add((Control) this.button30);
      this.groupBox3.Controls.Add((Control) this.button28);
      this.groupBox3.Controls.Add((Control) this.button26);
      this.groupBox3.Controls.Add((Control) this.button14);
      this.groupBox3.Controls.Add((Control) this.button13);
      this.groupBox3.Controls.Add((Control) this.button12);
      this.groupBox3.Controls.Add((Control) this.button11);
      this.groupBox3.Location = new Point(534, 344);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(229, 217);
      this.groupBox3.TabIndex = 55;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "レーザー位置調整";
      this.groupBox3.Enter += new EventHandler(this.groupBox3_Enter);
      this.button30.BackColor = Color.Transparent;
      this.button30.Location = new Point(84, 119);
      this.button30.Name = "button30";
      this.button30.Size = new Size(67, 34);
      this.button30.TabIndex = 28;
      this.button30.Text = "中心に戻る";
      this.button30.UseVisualStyleBackColor = false;
      this.button30.Click += new EventHandler(this.button30_Click);
      this.button28.BackColor = Color.Transparent;
      this.button28.Location = new Point(27, 38);
      this.button28.Name = "button28";
      this.button28.Size = new Size(87, 36);
      this.button28.TabIndex = 26;
      this.button28.Text = "彫刻範囲プレビュー";
      this.button28.UseVisualStyleBackColor = false;
      this.button28.Click += new EventHandler(this.button28_Click);
      this.button26.BackColor = Color.Transparent;
      this.button26.Location = new Point(119, 38);
      this.button26.Name = "button26";
      this.button26.Size = new Size(82, 36);
      this.button26.TabIndex = 25;
      this.button26.Text = "原点に戻る";
      this.button26.UseVisualStyleBackColor = false;
      this.button26.Click += new EventHandler(this.button26_Click_1);
      this.label13.AutoSize = true;
      this.label13.FlatStyle = FlatStyle.Popup;
      this.label13.Font = new Font("宋体", 13f);
      this.label13.Location = new Point(241, 19);
      this.label13.Name = "label13";
      this.label13.Size = new Size(44, 18);
      this.label13.TabIndex = 37;
      this.label13.Text = "缩放";
      this.label13.Visible = false;
      this.label13.Click += new EventHandler(this.label13_Click);
      this.textBox4.CausesValidation = false;
      this.textBox4.Location = new Point(831, 322);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(53, 21);
      this.textBox4.TabIndex = 24;
      this.textBox4.Text = "100";
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.textBox4.TextChanged += new EventHandler(this.textBox4_TextChanged);
      this.textBox4.KeyPress += new KeyPressEventHandler(this.textBox4_KeyPress);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(816, 424);
      this.label7.Name = "label7";
      this.label7.Size = new Size(53, 12);
      this.label7.TabIndex = 27;
      this.label7.Text = "步进值：";
      this.label7.Visible = false;
      this.label7.Click += new EventHandler(this.label7_Click);
      this.timer1.Enabled = true;
      this.timer1.Interval = 300;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.button29.BackColor = Color.Transparent;
      this.button29.ForeColor = Color.Blue;
      this.button29.Location = new Point(610, 99);
      this.button29.Name = "button29";
      this.button29.Size = new Size(71, 36);
      this.button29.TabIndex = 56;
      this.button29.Text = "一時停止";
      this.button29.UseVisualStyleBackColor = false;
      this.button29.Click += new EventHandler(this.button29_Click);
      this.button29.MouseDown += new MouseEventHandler(this.button29_MouseDown);
      this.button31.Location = new Point(836, 282);
      this.button31.Name = "button31";
      this.button31.Size = new Size(55, 19);
      this.button31.TabIndex = 57;
      this.button31.Text = "button31";
      this.button31.UseVisualStyleBackColor = true;
      this.button31.Visible = false;
      this.button31.Click += new EventHandler(this.button31_Click);
      this.label8.BackColor = Color.Black;
      this.label8.Location = new Point(25, 60);
      this.label8.Name = "label8";
      this.label8.Size = new Size(500, 1);
      this.label8.TabIndex = 58;
      this.label8.Text = "label8";
      this.label9.BackColor = Color.Black;
      this.label9.Location = new Point(25, 560);
      this.label9.Name = "label9";
      this.label9.Size = new Size(500, 1);
      this.label9.TabIndex = 59;
      this.label9.Text = "label9";
      this.label10.BackColor = Color.Black;
      this.label10.Location = new Point(25, 60);
      this.label10.Name = "label10";
      this.label10.Size = new Size(1, 500);
      this.label10.TabIndex = 60;
      this.label10.Text = "label10";
      this.label11.BackColor = Color.Black;
      this.label11.Location = new Point(525, 60);
      this.label11.Name = "label11";
      this.label11.Size = new Size(1, 500);
      this.label11.TabIndex = 61;
      this.label11.Text = "label11";
      this.button32.BackColor = Color.Transparent;
      this.button32.Font = new Font("宋体", 20f);
      this.button32.Image = (Image) componentResourceManager.GetObject("button32.Image");
      this.button32.Location = new Point(487, 13);
      this.button32.Name = "button32";
      this.button32.Size = new Size(35, 35);
      this.button32.TabIndex = 62;
      this.button32.UseVisualStyleBackColor = false;
      this.button32.Click += new EventHandler(this.button32_Click);
      this.timer2.Enabled = true;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Location = new Point(32, 543);
      this.label12.Name = "label12";
      this.label12.Size = new Size(0, 12);
      this.label12.TabIndex = 63;
      this.timer3.Interval = 1000;
      this.timer3.Tick += new EventHandler(this.timer3_Tick);
      this.groupBox4.Controls.Add((Control) this.trackBar4);
      this.groupBox4.Controls.Add((Control) this.textBox5);
      this.groupBox4.Location = new Point(818, 135);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(228, 50);
      this.groupBox4.TabIndex = 64;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "レーザー彫刻パラメータ調整";
      this.AllowDrop = true;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Gainsboro;
      this.ClientSize = new Size(772, 567);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button32);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.trackBar3);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.button31);
      this.Controls.Add((Control) this.button10);
      this.Controls.Add((Control) this.button29);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.button27);
      this.Controls.Add((Control) this.button16);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.button18);
      this.Controls.Add((Control) this.button19);
      this.Controls.Add((Control) this.button15);
      this.Controls.Add((Control) this.button25);
      this.Controls.Add((Control) this.button24);
      this.Controls.Add((Control) this.button23);
      this.Controls.Add((Control) this.button22);
      this.Controls.Add((Control) this.button21);
      this.Controls.Add((Control) this.button20);
      this.Controls.Add((Control) this.jdt);
      this.Controls.Add((Control) this.button17);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.label3);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (Form1);
      this.Text = "激光雕刻机";
      this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new EventHandler(this.Form1_Load);
      this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
      this.panel2.ResumeLayout(false);
      this.trackBar3.EndInit();
      this.trackBar2.EndInit();
      this.trackBar1.EndInit();
      this.trackBar4.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void MyInvoke();

    public struct wen_ben
    {
      public Bitmap wen_zi;
      public Point diao;
    }

    [System.Flags]
    private enum ExecutionFlag : uint
    {
      System = 1,
      Display = 2,
      Continus = 2147483648, // 0x80000000
    }
  }
}
