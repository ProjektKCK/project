package kck;
import java.applet.Applet;
import java.awt.Graphics;

public class Disp extends Loop{

	public void init(){
		setSize(1024,720);
		Thread th = new Thread(this);
		th.start();
		offscreen = createImage(1024,720);
		d = offscreen.getGraphics();
		addKeyListener(this);
	}
	public void paint(Graphics g){
		d.clearRect(0,0,1024,720);
		d.drawOval(x,y,20,20);
		g.drawImage(offscreen,0,0,this);
	}
	public void update(Graphics g){
		paint(g);
	}
}
