package dev.yukie.ss.logic;

import java.io.*;
import java.net.*;

import dev.yukie.ss.Main;

public class Client extends Thread {
    public void run() {
        try {
            var conn = new Socket("127.0.0.1", 49200);
            System.out.println("[Client] Connection open");

            var writer = new BufferedWriter(new OutputStreamWriter(conn.getOutputStream()));
            var reader = new BufferedReader(new InputStreamReader(conn.getInputStream()));

            int _numbers[] = {82, 19, 43, 2, 61};

            for (int n : _numbers) {
                send(writer, "EVAL " + Integer.toString(n));
                System.out.println("[Client] " + reader.readLine());
            }
            send(writer, "LOGOUT");

            writer.close();
            reader.close();
            conn.close();

            System.out.println("[Client] Connection closed");
        } catch (IOException e) {
            System.out.println("[Client] Connection failed");
        }
    }

    private void send(BufferedWriter writer, String s) throws IOException {
        System.out.println("[Worker] Sending: " + s);

        writer.write(s);
        writer.newLine();
        writer.flush();

        try {
            Main.pause();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
