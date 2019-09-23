package co.edu.javeriana.pica.jvm.performance.mm;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.zip.GZIPOutputStream;

public class Main {
    public static void main(String[] args) {

        if (args == null || args.length != 1) {
            throw new IllegalArgumentException("Incorrect number of arguments. It's only expected the file name to GZIP.");
        }

        if (!Files.exists(Paths.get(args[0]))) {
            throw new IllegalArgumentException("The source file doesn't exist: " + args[0]);
        }
        

        SimpleDateFormat formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
        Calendar calendar = Calendar.getInstance();
        System.out.println(formatter.format(calendar.getTime()));

        try (FileOutputStream fos = new FileOutputStream(args[0] + ".gz");
        	GZIPOutputStream gzos = new GZIPOutputStream(fos)) {
				byte[] buffer = new byte[8192];
				int length;
				try (FileInputStream fis = new FileInputStream(args[0])) {
					while ((length = fis.read(buffer)) > 0) {
						gzos.write(buffer, 0, length);
					}
				}
        } catch (IOException ex) {
            System.out.println("An error occurred while processing the output file: " + ex);
            System.exit(-1);
        }
        
        calendar = Calendar.getInstance();
        System.out.println(formatter.format(calendar.getTime()));
    }
}