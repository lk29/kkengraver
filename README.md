# Description of the engraver software

This software is intended to be used with a KKMoon laser engraver (3000mW).
It comes with ABSOLUTELY NO WARRANTY. It may or may not work with an other kind of
laser engraver.

## Preliminaries

The program is written in python (V3) and uses the python packages 'pyserial' and
'Pillow' (former PIL). So you have get them installed first. 

engraver.py is a command line tool without any GUI. But it has (nearly) every
feature the Windows software that came with the engraver has.


You can get a short help by just typing: `python3 engraver.py -h` or `./engraver.py -h`
if you have made it executable.

    usage: engraver [-h] [-d device] [-s speed] [-v] [--fan] [--no-fan] [-m x:y]
                    [-f x:y] [-F imagefile] [-c x|y] [-H] [-D depth] [-P power]
                    [--checkerboard tile_size number] [-i imagefile] [-t text]
                    [--font font] [-T cw|ccw|turn|tb|lr [cw|ccw|turn|tb|lr ...]]
                    [-S w:h] [--invert] [--limit steps] [--dry-run [imagefile]]
    
    Engraver program for using a KKMoon laser engraver V0.9 (c) 2019 by Bernd
    Breitenbach This program comes with ABSOLUTELY NO WARRANTY. This is free
    software, and you are welcome to redistribute it under certain conditions; See
    COPYING for details.
    
    optional arguments:
      -h, --help            show this help message and exit
      -d device, --device device
                            the serial device (default: /dev/ttyUSB0)
      -s speed, --speed speed
                            the speed of the serial device (default: 115200)
      -v, --verbosity       increase verbosity level (default: 0)
      --fan                 switch fan on (default: None)
      --no-fan              switch fan off (default: None)
      -m x:y                move the laser x/y steps (default: None)
      -f x:y                draw a moving frame (default: None)
      -F imagefile, --image-frame imagefile
                            draw a moving frame as large as the given image
                            (default: None)
      -c x|y, --center-only x|y
                            draw a center line only (x or y) with the other
                            dimension taken from an image. Has an effect only when
                            used with the -F option (default: None)
      -H, --home            move the laser to pos 0/0 (default: False)
      -D depth, --depth depth
                            set the burn depth of the laser (0-100) (default: 10)
      -P power, --power power
                            set the laser power (0-100) (default: 100)
      --checkerboard tile_size number
                            engrave a quadratic checkerboard pattern of given tile
                            size and number (default: None)
      -i imagefile, --image imagefile
                            the image file to engrave (default: None)
      -t text, --text text  the text to engrave; you also have to specify a font
                            with the --font option (default: None)
      --font font           the truetype/opentype font used to engrave text
                            (default: None)
      -T cw|ccw|turn|tb|lr [cw|ccw|turn|tb|lr ...], --transform cw|ccw|turn|tb|lr [cw|ccw|turn|tb|lr ...]
                            transform the image after any other operation just
                            before engraving. The following transformations are
                            possible: cw - rotate 90 degrees clockwise; ccw -
                            rotate 90 degrees counterclockwise; turn - rotate 180
                            degrees ; tb - flip top-bottom ; lr - flip left-right
                            (default: None)
      -S w:h, --maxsize w:h
                            scale the image down to match maximal width and
                            height; the aspect ratio is kept (default: None)
      --invert              invert the image/text before engraving (default:
                            False)
      --limit steps         set maximum no. of steps in x/y direction (default:
                            1575)
      --dry-run [imagefile]
                            do not engrave anything; you can specify an optional
                            file for saving engraving data (default: None)
    
    All distances and sizes can be specified in steps or millimeter by just adding
    mm to a given number. The KKMoon engraver has a resolution of 500 steps/inch
    (19.685.. steps/mm)
    
Prior sending any commands to the KKMoon engraver you have to power it up and connect
it to the computer. Depending on your OS you may have to install a driver for the serial device.

Under Linux you can check whether the device is recognized by looking at the output of `dmesg`.
You should see something like this:

    [1172392.928109] usb 3-5: new full-speed USB device number 16 using xhci_hcd
    [1172393.057149] usb 3-5: New USB device found, idVendor=1a86, idProduct=7523
    [1172393.057152] usb 3-5: New USB device strings: Mfr=0, Product=2, SerialNumber=0
    [1172393.057154] usb 3-5: Product: USB2.0-Serial
    [1172393.057681] ch341 3-5:1.0: ch341-uart converter detected
    [1172393.061184] usb 3-5: ch341-uart converter now attached to ttyUSB0

The last line shows the here the name of our device: `ttyUSB0`.
This device has to be specified with the `-d` option. The KKMoon normally
works with 115200 baud so you don't have the specify the speed.

## First Test

To check whether the engraver gets detected just enter (if using a Windows OS you may have to replace `/dev/ttyUSB0`
with your port name e.g. `COM3`):

    ./engraver.py -d /dev/ttyUSB0 -v

The `-v` increases the verbosity and you should see something like this:

    [DEBUG]: opening device /dev/ttyUSB0
    [DEBUG]: connecting...
    [DEBUG]: sending:[10, 0, 4, 0, 255, 0, 4, 0]
    [DEBUG]: got acknowledge
    [DEBUG]: ...connected
    
This indicates that the engraver is regcognized and you can try some other commands.
If you get an error message like this:

    [DEBUG]: opening device /dev/ttyUSB0
    [FATAL]: [Errno 2] could not open port /dev/ttyUSB0: [Errno 2] No such file or directory: '/dev/ttyUSB0'

then the serial device ist not present (perhaps a connection problem).
If you got something like this (after a timeout):

    [DEBUG]: opening device /dev/ttyUSB0
    [DEBUG]: connecting...
    [DEBUG]: sending:[10, 0, 4, 0, 255, 0, 4, 0]
    [FATAL]: didn't got acknowledge; got:b''

then the serial device is present, but the the KKMoon engraver could not be detected.
Perhaps due to another model or other firmware.


## Commands

If the above things worked fine. We can now try some commands.

### The Fan

The case fan of the KKMoon can be switched on/off with the `--fan/--no-fan` option.
If not given the state of the fan will remain unchanged.
The cooling fan on the laser head is always on and can not be switched off with this option.

### Moving the laser

By entering `./engraver.py -v -m 10:10 -d /dev/ttyUSB0` the laser will move by a small amount.
You see this output:

    [DEBUG]: opening device /dev/ttyUSB0
    [DEBUG]: connecting...
    [DEBUG]: sending:[10, 0, 4, 0, 255, 0, 4, 0]
    [DEBUG]: got acknowledge
    [DEBUG]: ...connected
    [DEBUG]: start moving delta_x=10px (0.5mm) delta_y=10px (0.5mm)
    [DEBUG]: sending:[1, 0, 7, 0, 10, 0, 10]
    [DEBUG]: got acknowledge
    [DEBUG]: move finished
    laser moved x:10px (0.5mm) delta_y=10px (0.5mm)

It shows that the laser got moved roughly 0.5 millimeters in x and y direction.
You can revert this movement by entering: `./engraver.py -v -m -10:-10 -d /dev/ttyUSB0`
(Due to a bug in an old version of the python argsparse package it can happen, that
the the negative values aren't regcognized correctly. You can get around this bug by
modifying the command slightly:  `./engraver.py -v -m ' -10:-10' -d /dev/ttyUSB0`)

You also can specify the distance in millimeters instead of pixels/steps by adding
mm to the value.
The command `./engraver.py -v -m 7.5mm:3.5mm -d /dev/ttyUSB0` will move the laser
7.5 millimeters in x and 3.5mm in y direction.

You can also leave out the value for x- or y-direction:

`./engraver.py -v -m :7mm -d /dev/ttyUSB0` will only move the laser 3.5mm in y-direction

and `./engraver.py -v -m ' -4mm' -d /dev/ttyUSB0` will only move the laser -4mm in x-direction


### Depth and Power

With the two parameters depth (-D) and power (-P) you can adjust the final look of the engraving.
When increasing the depth parameter the laser move more slowly and stays longer at the same point.
This results in removing more material an a deeper engraving. 
Lowering the power results in a weaker laser beam. I assume the laser is controlled through PWM and so the
on-time during a cycle is probably decreased.


### Home

You can move the laser to the home position (0,0) with the `-H` option. But be careful
the KKMoon has no endswitches and the firmware will drive both stepper motors the full distance
(89mm) towards the origin. So they eventually will hit the case.

### Showing a moving frame

As the original software does you can also show a moving frame to align the workpiece
before doing the engraving.
Enter `./engraver.py -v -f 25mm:10mm -d /dev/ttyUSB0` and you see the laser repetitive
drawing a frame until you hit the return key. 

You can also use you image file you want to engrave to show a frame. Just enter
`./engraver.py -F <yourimage> -d /dev/ttyUSB0` and you will an output like this

    showing frame x:283px (14.4mm) y:309px (15.7mm)
    press return to finish

After pressing the return key. The laser will complete the current frame until it reaches
the origin of the frame.
As an image format you can use all formats the Pillow (PIL) package support (e.g. jpg/png/gif).

It is also possible to restrict the frame to the x- or y-axis by using the `-c` option:

`./engraver.py -c x -F <yourimage> -d /dev/ttyUSB0`

will show a line in x direction in the middle of the y size of the image.


### Engraving

The program contains a function to engrave a checkerboard pattern as test. For example
if you enter: `./engraver.py --checkerboard 4mm 4 -d /dev/ttyUSB0` it will engrave a checkboard
pattern 4 by 4 with a tile size of 4mm. You will take a while and you see some output:

    waiting for engraver
    sending data (312 rows) ...
    100% done
    engraving...
    completed!

It will engrave the pattern with the default values for engravement depth (10) and laser power
(100). Both values can be changed between 0 and 100.

Instead of the test pattern you can specify your image file:

`./engraver.py -i <yourimage> -D 15 -d /dev/ttyUSB0`

or with a given maximum size by keeping the aspect ratio:

`./engraver.py -i <yourimage> -S 5mm:5mm -D 15 -d /dev/ttyUSB0`


You see an output like this:

    image resized to width:89px (4.5mm) height:98px (5.0mm)
    preparing image data width:89px (4.5mm) height:98px (5.0mm)
    waiting for engraver
    sending data (98 rows) ...
    100% done
    engraving...
    completed!

Note: you only can shrink your image you cannot enlarge an image with this option.

### Engraving Text

With the `-t` and the `--font` options you can engrave a text with a given font. Here the `-S` option
is very useful for setting the maximum height or width of the engraving.
With the `--font` you must specify a TrueType or OpenType font file. 

The command `./engraver.py -t "Hello!" --font fonts/arial.ttf -S 25mm:10mm -d /dev/ttyUSB0`
engraves the the word 'Hello' using the font arial.ttf in the subdirectory fonts and the
with the maximal dimensions of 25mm in x direction and 10mm in y direction.

I do not provide any fonts with this program. You can find a lot by searching the internet
for 'open source fonts' or using the one that comes with your OS.

### Transform 

With the `-T` option you can rotate and/or mirror your image or text before engraving after any other operation.
You can specify multiple transformation after the option e.g:

`./engraver.py -t "Hello!" --font fonts/arial.ttf -T cw tb -S 25mm:10mm -D 15 -d /dev/ttyUSB0`

first rotates the text clockwise and afterwards mirrors it about the y axis (flips top-bottom).

Note: the scaling with `-S` happens *before* tranforming. So in the above example 25mm is the maximal length of
the text image and 10mm its maximal height.

### Dry Run

With the `--dry-run` option you can test option without sending any commands to the device. It does not even has
to be connected to the computer.

If the a file name is specified with this option and an image or text should be engraved the final image will be saved
into a file with the given name.

## Emergency

If something go wrong during engraving, hit the interrupt key (Ctrl-c) and the engraving
will pause. You can abort the process now by hitting the return key or continue it by
entering `n` followed by a return.



