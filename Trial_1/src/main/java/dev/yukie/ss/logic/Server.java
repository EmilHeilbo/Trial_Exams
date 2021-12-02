package dev.yukie.ss.logic;

import java.net.*;
import java.util.*;

public class Server extends Thread {
    private ArrayList<Worker> workers;
    private int port;
    private boolean end;

    public Server(int port) {
        this.port = port;
        this.end = false;
        workers = new ArrayList<Worker>();
    }

    public void run() {
        try {
            var server = new ServerSocket(port, 100);
            server.setSoTimeout(100);
            System.out.println("[Server] ONLINE");

            while(!end)
                try {
                    var conn = server.accept();
                    var worker = new Worker(this, conn);
                    workers.add(worker);
                    worker.start();
                } catch (SocketTimeoutException e) {
                    
                }
            server.close();

            System.out.println("[Server] OFFLINE");
        } catch (Exception e) {
            System.out.println("ERROR: Connection failed");
        }
    }
    
    public void quit() {
        end = true;
    }

    public boolean isEven(int n) {
        switch(n % 2) {
            case 0:
                return true;
            default:
                return false;
        }
    }
}
