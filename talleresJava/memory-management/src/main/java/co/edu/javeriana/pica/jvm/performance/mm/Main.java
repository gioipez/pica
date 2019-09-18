package co.edu.javeriana.pica.jvm.performance.mm;

import java.util.Arrays;
import java.util.List;
import java.util.concurrent.ForkJoinPool;
import java.util.concurrent.RecursiveTask;
import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.stream.Collectors;
import java.util.stream.IntStream;
import java.util.zip.GZIPOutputStream;

class CompressFile extends RecursiveTask<FileOutputStream> {

	ByteArrayOutputStream baos;
	private int from;
    private int to;
    private int threshold;
    private FileOutputStream fos;
    
	public CompressFile(FileOutputStream fos, ByteArrayOutputStream baos, int from , int to , int threshold) {
		
		this.baos = baos;
		this.from = from;
        this.to = to;
        this.threshold = threshold;
        this.fos = fos;
		
	}
	
	@Override
    public FileOutputStream compute() {
		
		if ((to - from) <= threshold) {
			
			System.out.printf("%s: Working from %d to %d%n",
                    Thread.currentThread().getName(),
                    from, to);
			try {
			for (byte b : Arrays.copyOfRange(baos.toByteArray(), from, to)) {
                
					fos.write(b);
					fos.flush();
            }
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return	fos;
		}
		else {
            int splitIndex = (to + from) / 2;
            
            

            CompressFile leftSide = new CompressFile(fos, baos, from, splitIndex, threshold);
            leftSide.fork();

            CompressFile rightSide = new CompressFile(fos, baos, splitIndex +1 , to , threshold);
            FileOutputStream rightSideResult = rightSide.compute();

            return leftSide.join();
        }
		
	}
}

public class Main {
	
	private static final int NUMBER_OF_THREADS = Runtime.getRuntime().availableProcessors() * 2;

    private static final int BUFFER_SIZE = 256;
    
    public static void main(String[] args) {
    	
    	System.out.println("hilos -> " + NUMBER_OF_THREADS);
    	
        if (args == null || args.length != 1) {
            throw new IllegalArgumentException("Incorrect number of arguments. It's only expected the file name to GZIP.");
        }

        if (!Files.exists(Paths.get(args[0]))) {
            throw new IllegalArgumentException("The source file doesn't exist: " + args[0]);
        }
        

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        try (FileInputStream fis = new FileInputStream(args[0]);
             GZIPOutputStream gzipos = new GZIPOutputStream(baos)) {
            int n;
            byte[] buffer = new byte[BUFFER_SIZE];
            while ((n = fis.read(buffer)) != -1) {
                gzipos.write(buffer, 0, n);
            }
            
            int tamanoBuffer = buffer.length;
        } catch (IOException ex) {
            System.out.println("An error occurred while processing the input file: " + ex);
            System.exit(-1);
        }
        
        int cantbytes = baos.toByteArray().length;
        
        System.out.println("cantbytes -> " + cantbytes);
        
        int THRESHOLD = cantbytes / NUMBER_OF_THREADS;
        
        System.out.println("THRESHOLD -> " + THRESHOLD);
        
        

        try (FileOutputStream fos = new FileOutputStream(
                new File(Paths.get(args[0]).normalize().toAbsolutePath().getParent().toFile(), Paths.get(args[0]).normalize().getFileName() + ".gz"))) {
        	ForkJoinPool pool = new ForkJoinPool(NUMBER_OF_THREADS);
        	FileOutputStream compress = pool.invoke(new CompressFile(fos,baos, 0,cantbytes, THRESHOLD));
        	//pool.execute(compress);
        	
        } catch (IOException ex) {
            System.out.println("An error occurred while processing the output file: " + ex);
            System.exit(-1);
        }
    }
}