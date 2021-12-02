package dev.yukie.ss.data;

public class Message {
    private String rcpt, msg;

    public Message(String rcpt, String msg) {
        this.rcpt = rcpt;
        this.msg = msg;
    }

    public boolean check(String user) {
        return rcpt.equalsIgnoreCase(user);
    }

    public String get() {
        return msg;
    }
}
