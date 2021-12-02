package dev.yukie.ss;

import dev.yukie.ss.logic.*;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        // Use a dynamic port (range is 49152-65535)
        var server = new Server(49200);
        server.start();
        pause();
        var client = new Client();
        client.start();
        Thread.sleep(2000);
        server.quit();
    }

    public static void pause() throws InterruptedException {
        Thread.sleep(50);
    }
}
