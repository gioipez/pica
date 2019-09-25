package co.edu.javeriana.pica.jvm.performance.pf;

import java.awt.image.BufferedImage;
import java.util.concurrent.ForkJoinPool;
import java.io.ByteArrayOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.concurrent.RecursiveTask;

public class ProcessImage {

	private static final int NUMBER_OF_THREADS = Runtime.getRuntime().availableProcessors() * 4;
	
    public static BufferedImage process(BufferedImage srcImage) {
        int with = srcImage.getWidth();
        int height = srcImage.getHeight();
        BufferedImage dstImage = new BufferedImage(with, height, BufferedImage.TYPE_INT_ARGB);

        
        System.out.println("cantbytes -> " + with);
        
        int THRESHOLD = with / NUMBER_OF_THREADS;
        
        System.out.println("THRESHOLD -> " + THRESHOLD);
        
        ForkJoinPool pool = new ForkJoinPool(NUMBER_OF_THREADS);
        dstImage = pool.invoke(new ParalelProcessImage(dstImage, srcImage, 0,with, THRESHOLD));
        
        return dstImage;
    }
}


class ParalelProcessImage extends RecursiveTask<BufferedImage> {

	BufferedImage dstImage;
	BufferedImage srcImage;
	private int from;
    private int to;
    private int threshold;
    private int heightImage;
    
    
	public ParalelProcessImage(BufferedImage dstImage , BufferedImage srcImage, int from , int to , int threshold) {
		
		this.dstImage = dstImage;
		this.from = from;
        this.to = to;
        this.threshold = threshold;
        this.heightImage = srcImage.getHeight();
        this.srcImage = srcImage;		
	}
	
	@Override
    public BufferedImage compute() {
		
		if ((to - from) <= threshold) {
			
			System.out.printf("%s: Working from %d to %d%n",
                    Thread.currentThread().getName(),
                    from, to);
			for (int x = from; x < to; x++) {
			    for (int y = 0; y < heightImage; y++) {
			        dstImage.setRGB(x, y, ProcessPixel.process(srcImage, x, y).getRBGAsInteger());
			    }
			}
			return	dstImage;
		}
		else {
            int splitIndex = (to + from) / 2;
            
            

            ParalelProcessImage leftSide = new ParalelProcessImage(dstImage, srcImage, from, splitIndex, threshold);
            leftSide.fork();

            ParalelProcessImage rightSide = new ParalelProcessImage(dstImage, srcImage, splitIndex +1 , to , threshold);
            BufferedImage rightSideResult = rightSide.compute();

            return leftSide.join();
        }
		
	}
}
