package kck;

import java.applet.Applet;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyListener;
import java.awt.event.KeyEvent;

public class Loop extends Applet implements Runnable, KeyListener {

	public int x, y;
	public Image offscreen;
	public Graphics d;
	public boolean up, down, left, right;
	
	
	public void run(){
		while(true){
			if (left == true){
				x-=2;
			}
			if (right == true){
				x+=2;
			}
			if (up == true){
				y-=2;
			}
			if (down == true){
				y+=2;
			}
		repaint();
		try{
			Thread.sleep(200);
		}catch(InterruptedException e){
			e.printStackTrace();
		}
		}
	}
	
	public void keyPressed(KeyEvent e){
		if (e.getKeyCode() == 37){
			left = true;
		}
		if (e.getKeyCode() == 38){
			up = true;
		}
		if (e.getKeyCode() == 39){
			right = true;
		}
		if (e.getKeyCode() == 40){
			down = true;
		}
	}
	public void keyReleased(KeyEvent e){
		if (e.getKeyCode() == 37){
			left = false;
		}
		if (e.getKeyCode() == 38){
			up = false;
		}
		if (e.getKeyCode() == 39){
			right = false;
		}
		if (e.getKeyCode() == 40){
			down = false;
		}
	}
	public void keyTyped(KeyEvent e){}
	
}
