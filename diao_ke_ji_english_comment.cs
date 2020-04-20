// Decompiled with JetBrains decompiler
// Type: 微型雕刻机2.diao_ke_ji
// Assembly: 微型雕刻机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D85B3EF6-6EAE-4E7B-9FA6-02FD579957F4
// Assembly location:  Laser engraving machine.exe
// comment make by lk29

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace 微型雕刻机2
{
  internal class diao_ke_ji // Engraving machine
  {
    public int kuan_gao = 800; // Width Height
    public SerialPort com;
    public int x;
    public int y;
    public Bitmap tu;
    public Bitmap tu_pian; // image
    public bool lianjie; // link
    public bool fanhui; // return
    private bool jinru; // enter

    public diao_ke_ji(SerialPort p) // Engraving machine
    {
      this.tu_pian = new Bitmap(this.kuan_gao, this.kuan_gao);
      Graphics.FromImage((Image) this.tu_pian).Clear(Color.White);
      this.tu = this.tu_pian;
      this.com = p;
    }

    private void jieshou() // receive
    {
      while (true)
      {
        if (this.com.IsOpen)
        {
          try
          {
            if (0 < this.com.BytesToRead)
            {
              if (this.com.ReadByte() == 9)
                this.fanhui = true;
            }
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.ToString());
          }
        }
        Thread.Sleep(1);
      }
    }

    private bool fasong_lianjie() // Send connection
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 10,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
      }
      int num = 10;
      this.lianjie = false;
      this.fanhui = false;
      while (0 < num--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件(); // Handling events
        if (this.fanhui)
        {
          this.lianjie = true;
          return true;
        }
      }
      this.com.Close();
      return false;
    }

    public bool li_san_mo_shi() // Discrete mode
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 27,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
      }
      int num = 10;
      this.fanhui = false;
      while (0 < num--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool fei_li_san_mo_shi() // Non-discrete mode
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 28,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
      }
      int num = 10;
      this.fanhui = false;
      while (0 < num--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public static void 处理事件() // Handling events
    {
      Application.DoEvents();
    }

    public bool lian_jie() // link
    {
      if (this.lianjie)
        return true;
      foreach (string portName in SerialPort.GetPortNames())
      {
        try
        {
          this.com.PortName = portName;
          this.com.BaudRate = 115200;
          this.com.Open();
        }
        catch (Exception ex)
        {
        }
        if (this.fasong_lianjie())
        {
          this.lianjie = true;
          return true;
        }
      }
      return false;
    }

    public Bitmap hui_du(int zhi) // Grayscale
    {
      Bitmap bitmap = new Bitmap((Image) this.tu);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num = ((int) destination[index] * 30 + (int) destination[index + 1] * 59 + (int) destination[index + 2] * 11) / 100;
        if (num < 253)
          num -= zhi - 128;
        if (num > 253)
          num = 253;
        if (num < 1)
          num = 1;
        if (destination[index + 3] == (byte) 0)
          num = (int) byte.MaxValue;
        source[index] = (byte) num;
        source[index + 1] = (byte) num;
        source[index + 2] = (byte) num;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    public Bitmap hei_bai(int zhi) // Black and white
    {
      Bitmap bitmap = new Bitmap((Image) this.tu);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num = ((int) destination[index] * 30 + (int) destination[index + 1] * 59 + (int) destination[index + 2] * 11) / 100 <= zhi ? 0 : (int) byte.MaxValue;
        if (destination[index + 3] == (byte) 0)
          num = (int) byte.MaxValue;
        source[index] = (byte) num;
        source[index + 1] = (byte) num;
        source[index + 2] = (byte) num;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    public int qu_hei_dian() // Go to the black shop ??
    {
      int num1 = 0;
      Bitmap bitmap = new Bitmap((Image) this.tu);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num2 = (int) destination[index];
        if (destination[index] == (byte) 0)
          ++num1;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return num1;
    }

    public Bitmap dou_dong2(int zhi) // Jitter 2
    {
      Bitmap bitmap = new Bitmap((Image) this.tu);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length];
      byte[] source = new byte[length];
      Marshal.Copy(scan0, destination, 0, length);
      for (int index = 0; index < destination.Length; index += 4)
      {
        int num1 = (int) destination[index];
        int num2;
        int num3;
        if (num1 > 128 + (zhi - 128))
        {
          if (num1 > (int) byte.MaxValue)
            num1 = (int) byte.MaxValue;
          num2 = num1 - (int) byte.MaxValue;
          num3 = (int) byte.MaxValue;
        }
        else
        {
          if (num1 < 0)
            num1 = 0;
          num2 = num1;
          num3 = 0;
        }
        int num4 = 375 * num2 / 1000;
        int num5 = 25 * num2 / 100;
        if (index + 4 < destination.Length)
        {
          int num6 = (int) destination[index + 4] + num4;
          if (num6 > (int) byte.MaxValue)
            num6 = (int) byte.MaxValue;
          if (num6 < 0)
            num6 = 0;
          destination[index + 4] = (byte) num6;
        }
        if (index + bitmap.Width * 4 < destination.Length)
        {
          int num6 = (int) destination[index + bitmap.Width * 4] + num4;
          if (num6 > (int) byte.MaxValue)
            num6 = (int) byte.MaxValue;
          if (num6 < 0)
            num6 = 0;
          destination[index + bitmap.Width * 4] = (byte) num6;
        }
        if (index + bitmap.Width * 4 + 1 < destination.Length)
        {
          int num6 = (int) destination[index + bitmap.Width * 4 + 1] + num5;
          if (num6 > (int) byte.MaxValue)
            num6 = (int) byte.MaxValue;
          if (num6 < 0)
            num6 = 0;
          destination[index + bitmap.Width * 4 + 1] = (byte) num6;
        }
        source[index] = (byte) num3;
        source[index + 1] = (byte) num3;
        source[index + 2] = (byte) num3;
        source[index + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    public Bitmap dou_dong(int zhi) // shake ??
    {
      Bitmap bitmap = new Bitmap((Image) this.tu);
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
      IntPtr scan0 = bitmapdata.Scan0;
      int length1 = Math.Abs(bitmapdata.Stride) * bitmap.Height;
      byte[] destination = new byte[length1];
      byte[] source = new byte[length1];
      Marshal.Copy(scan0, destination, 0, length1);
      int length2 = destination.Length;
      int width = bitmap.Width;
      for (int index1 = 0; index1 < length2; index1 += 4)
      {
        int num1 = (int) destination[index1];
        int num2;
        int num3;
        if (num1 > zhi)
        {
          if (num1 > (int) byte.MaxValue)
            num1 = (int) byte.MaxValue;
          num2 = num1 - (int) byte.MaxValue;
          num3 = (int) byte.MaxValue;
        }
        else
        {
          if (num1 < 0)
            num1 = 0;
          num2 = num1;
          num3 = 0;
        }
        int num4 = 375 * num2 / 1000;
        int num5 = 25 * num2 / 100;
        int num6 = width * 4;
        int index2 = index1 + 4;
        int index3 = index1 + num6;
        if (index2 < length2)
        {
          int num7 = (int) destination[index2] + num4;
          if (num7 > (int) byte.MaxValue)
            num7 = (int) byte.MaxValue;
          if (num7 < 0)
            num7 = 0;
          destination[index2] = (byte) num7;
        }
        if (index3 < length2)
        {
          int num7 = (int) destination[index1 + num6] + num4;
          if (num7 > (int) byte.MaxValue)
            num7 = (int) byte.MaxValue;
          if (num7 < 0)
            num7 = 0;
          destination[index3] = (byte) num7;
        }
        if (index3 + 1 < length2)
        {
          int num7 = (int) destination[index3 + 1] + num5;
          if (num7 > (int) byte.MaxValue)
            num7 = (int) byte.MaxValue;
          if (num7 < 0)
            num7 = 0;
          destination[index3 + 1] = (byte) num7;
        }
        if (destination[index1 + 3] == (byte) 0)
          num3 = (int) byte.MaxValue;
        source[index1] = (byte) num3;
        source[index1 + 1] = (byte) num3;
        source[index1 + 2] = (byte) num3;
        source[index1 + 3] = byte.MaxValue;
      }
      Marshal.Copy(source, 0, scan0, length1);
      bitmap.UnlockBits(bitmapdata);
      return bitmap;
    }

    public bool yidong(int xx, int yy, PictureBox p, bool pp) // move
    {
      if (!this.jinru)
      {
        this.jinru = true;
        if (!this.com.IsOpen)
        {
          this.jinru = false;
          return false;
        }
        try
        {
          this.com.Write(new byte[7]
          {
            (byte) 1,
            (byte) 0,
            (byte) 7,
            (byte) (xx >> 8),
            (byte) xx,
            (byte) (yy >> 8),
            (byte) yy
          }, 0, 7);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.ToString());
          this.jinru = false;
          return false;
        }
        int num1 = 10;
        this.fanhui = false;
        while (0 < num1--)
        {
          Thread.Sleep(10);
          diao_ke_ji.处理事件();
          if (this.fanhui)
          {
            this.x = xx;
            this.y = yy;
            if (pp)
              p.Location = new Point(this.x - 3, this.y - 3);
            this.jinru = false;
            return true;
          }
        }
      }
      this.jinru = false;
      return false;
    }

    public bool yidong3(int xx, int yy, PictureBox p, bool pp) // move 3 ??
    {
      if (!this.jinru)
      {
        this.jinru = true;
        if (!this.com.IsOpen)
        {
          this.jinru = false;
          return false;
        }
        try
        {
          this.com.Write(new byte[7]
          {
            (byte) 1,
            (byte) 0,
            (byte) 7,
            (byte) (xx >> 8),
            (byte) xx,
            (byte) (yy >> 8),
            (byte) yy
          }, 0, 7);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.ToString());
          this.jinru = false;
          return false;
        }
        int num1 = 120;
        this.fanhui = false;
        while (0 < num1--)
        {
          Thread.Sleep(10);
          diao_ke_ji.处理事件();
          if (this.fanhui)
          {
            this.x = xx;
            this.y = yy;
            if (pp)
              p.Location = new Point(this.x - 3, this.y - 3);
            this.jinru = false;
            return true;
          }
        }
      }
      this.jinru = false;
      return false;
    }

    public bool yidong2(int xx, int yy, PictureBox p, bool pp) // move 2
    {
      if (!this.jinru)
      {
        this.jinru = true;
        if (!this.com.IsOpen)
        {
          this.jinru = false;
          return false;
        }
        try
        {
          this.com.Write(new byte[7]
          {
            (byte) 1,
            (byte) 0,
            (byte) 7,
            (byte) (xx >> 8),
            (byte) xx,
            (byte) (yy >> 8),
            (byte) yy
          }, 0, 7);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.ToString());
          this.jinru = false;
          return false;
        }
        int num1 = 500;
        this.fanhui = false;
        while (0 < num1--)
        {
          Thread.Sleep(10);
          diao_ke_ji.处理事件();
          if (this.fanhui)
          {
            this.x = xx;
            this.y = yy;
            if (pp)
              p.Location = new Point(this.x - 3, this.y - 3);
            this.jinru = false;
            return true;
          }
        }
      }
      this.jinru = false;
      return false;
    }

    public bool kai_deng() // Turn on the light
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 2,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool guan_deng()  // Turn off the lights
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 3,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool kai_feng()
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 4,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool kai_shi(int xx, int yy) // start ?
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[7]
        {
          (byte) 20,
          (byte) 0,
          (byte) 7,
          (byte) (xx >> 8),
          (byte) xx,
          (byte) (yy >> 8),
          (byte) yy
        }, 0, 7);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool jie_shu() // end 
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 21,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool guan_feng() // Potting
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 5,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool guan_feng2() // Potting 2?
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[1]{ (byte) 5 }, 0, 1);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool kai_feng2()
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[1]{ (byte) 4 }, 0, 1);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool zan_ting() // pause
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[1]{ (byte) 24 }, 0, 1);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool ji_xu() // continue
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[1]{ (byte) 25 }, 0, 1);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool fu_wei() //Reset - restoration?
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 6,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
        {
          this.x = 0;
          this.y = 0;
          return true;
        }
      }
      return false;
    }

    public bool hui_ling() //??
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 8,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool dian_deng(int s) //Electric light
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 7,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool go_x(int s)
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 11,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool go_y(int s)
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 12,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool shang(int s) // on (upper)
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 15,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool xia(int s) //lower (down)
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 16,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool zuo(int s) // do (make)
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 17,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool you(int s) // have
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[5]
        {
          (byte) 18,
          (byte) 0,
          (byte) 5,
          (byte) (s >> 8),
          (byte) s
        }, 0, 5);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool kai_kuang(int k, int g) // Mine
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[7]
        {
          (byte) 13,
          (byte) 0,
          (byte) 7,
          (byte) (k >> 8),
          (byte) k,
          (byte) (g >> 8),
          (byte) g
        }, 0, 7);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool guan_kuang() //?? Slam dunk
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 14,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool dao_yuandian() //To the origin
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 23,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool dao_zhongxin() // To the center
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 26,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 300;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool ting_zhi() // stop
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        this.com.Write(new byte[4]
        {
          (byte) 22,
          (byte) 0,
          (byte) 4,
          (byte) 0
        }, 0, 4);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      return true;
    }

    public bool guan_ruo_guang() // Turn off the weak light
    {
      return true;
    }

    public bool tuo_ji_da_yin() // Print offline
    {
      if (!this.com.IsOpen)
        return false;
      try
      {
        SerialPort com = this.com;
        byte[] numArray = new byte[7];
        numArray[0] = byte.MaxValue;
        numArray[1] = (byte) 23;
        byte[] buffer = numArray;
        com.Write(buffer, 0, 7);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num1 = 10;
      this.fanhui = false;
      while (0 < num1--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool zhi_lei_xing(int a) // Value type
    {
      byte num1 = a != 1 ? (byte) 26 : (byte) 24;
      if (!this.com.IsOpen)
        return false;
      try
      {
        SerialPort com = this.com;
        byte[] numArray = new byte[7];
        numArray[0] = byte.MaxValue;
        numArray[1] = num1;
        byte[] buffer = numArray;
        com.Write(buffer, 0, 7);
      }
      catch (Exception ex)
      {
        int num2 = (int) MessageBox.Show(ex.ToString());
        return false;
      }
      int num3 = 1000;
      this.fanhui = false;
      while (0 < num3--)
      {
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        if (this.fanhui)
          return true;
      }
      return false;
    }

    public bool gai_bian_F(int s) // Change F
    {
      return false;
    }

    public static byte[] sheng_cheng_tuoji(Bitmap bit) // Generate offline
    {
      byte[] numArray1 = new byte[31500];
      uint num1 = 0;
      byte[] numArray2 = new byte[8]
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
      for (int y = 0; y < bit.Height; ++y)
      {
        for (int index1 = 0; index1 < bit.Width; index1 += 8)
        {
          byte num2 = 0;
          for (int index2 = 0; index2 < 8; ++index2)
          {
            if (index1 + index2 < 500 && bit.GetPixel(index1 + index2, y).R == (byte) 0)
              num2 |= numArray2[index2];
          }
          numArray1[(IntPtr) num1++] = num2;
        }
      }
      return numArray1;
    }

    public void duoji(ProgressBar jdt) // Multistage
    {
      if (!this.lianjie)
      {
        int num1 = (int) MessageBox.Show("没有连接设备！"); // No device connected
      }
      else
      {
        jdt.Visible = true;
        byte[] buffer = diao_ke_ji.sheng_cheng_tuoji(this.tu_pian);
        if (!this.zhi_lei_xing(1))
          return;
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        for (int index = 0; index < 50; ++index)
        {
          this.fanhui = false;
          this.com.Write(buffer, 630 * index, 630);
          int num2 = 1800;
          jdt.Value = index * 2;
          while (!this.fanhui)
          {
            Thread.Sleep(1);
            diao_ke_ji.处理事件();
            if (num2-- == 0)
              return;
          }
        }
        jdt.Value = 0;
        jdt.Visible = false;
      }
    }

    private byte[] sheng_cheng_tuoji2(Point[] zhixian) // Generate offline 2
    {
      byte[] numArray = new byte[zhixian.Length * 4 + 2];
      for (int index = 0; index < zhixian.Length; ++index)
      {
        numArray[index * 4] = (byte) (zhixian[index].X >> 8);
        numArray[index * 4 + 1] = (byte) zhixian[index].X;
        numArray[index * 4 + 2] = (byte) (zhixian[index].Y >> 8);
        numArray[index * 4 + 3] = (byte) zhixian[index].Y;
      }
      numArray[numArray.Length - 2] = (byte) 254;
      numArray[numArray.Length - 1] = (byte) 254;
      return numArray;
    }

    public void duoji2(ProgressBar jdt, Point[] zhixian) // Multistage
    {
      if (!this.lianjie)
      {
        int num1 = (int) MessageBox.Show("没有连接设备！");
      }
      else
      {
        jdt.Visible = true;
        byte[] buffer = this.sheng_cheng_tuoji2(zhixian);
        if (!this.zhi_lei_xing(2))
          return;
        Thread.Sleep(10);
        diao_ke_ji.处理事件();
        int num2 = buffer.Length / 630;
        int num3;
        for (num3 = 0; num3 < num2; ++num3)
        {
          this.fanhui = false;
          this.com.Write(buffer, 630 * num3, 630);
          int num4 = 1800;
          jdt.Value = num3 * 2;
          while (!this.fanhui)
          {
            Thread.Sleep(1);
            diao_ke_ji.处理事件();
            if (num4-- == 0)
              return;
          }
        }
        this.fanhui = false;
        this.com.Write(buffer, 630 * num2, buffer.Length - 630 * num2);
        int num5 = 1800;
        jdt.Value = num3 / 5;
        while (!this.fanhui)
        {
          Thread.Sleep(1);
          diao_ke_ji.处理事件();
          if (num5-- == 0)
            return;
        }
        jdt.Value = 0;
        jdt.Visible = false;
      }
    }
  }
}
