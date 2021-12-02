package dev.yukie.ss.logic;

import java.io.*;
import java.net.*;

import dev.yukie.ss.Main;

public class Worker extends Thread {
    private Socket conn;
    private Server server;
    private boolean _odd = false;
    private boolean _even = false;

    public Worker(Server server, Socket conn) {
        this.server = server;
        this.conn = conn;
    }

    public void run() {
        System.out.println("[Server] Connection opened to: "
                + conn.getInetAddress().getHostAddress());
        try {
            var reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
            var writer = new BufferedWriter(new OutputStreamWriter(conn.getOutputStream()));
            Task:
            for(;;) {
                String line = reader.readLine();
                if(line == null)
                    break Task;

                String[] tokens = line.split("\\s+", 2);
                String cmd = tokens[0].toUpperCase();
                System.out.println("[Worker] Received command: " + cmd);
                switch(cmd) {
                    default:
                        System.out.println("[Worker] ERROR: Command not found (" + cmd + ")");
                        break;
                    case "LOGIN":
                        break;
                    case "EVAL":
                        String number = tokens[1];
                        eval(writer, number);
                        break;
                    case "LOGOUT":
                        break Task;
                }
            }
            reader.close();
            writer.close();

            System.out.println("[Worker] Connection closed");
        } catch (IOException e) {
            System.out.println("[Worker] ERROR: I/O interrupted");
        }
    }
    
    private void eval(BufferedWriter writer, String s) throws IOException {
        System.out.println("[Worker] Sending: " + s);
        String _s;

        if(server.isEven(Integer.parseInt(s))) {
            if(_even)
                _s = "igen lige";
            else {
                _even = !_even;
                _s = "lige";
            }
        } else {
            if(_odd)
                _s = "igen ulige";
            else {
                _odd = !_odd;
                _s = "ulige";
            }
        }

        writer.write(_s);
        writer.newLine();
        writer.flush();

        try {
            Main.pause();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
