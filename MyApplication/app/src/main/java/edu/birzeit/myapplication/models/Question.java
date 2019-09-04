package edu.birzeit.myapplication.models;


import com.google.gson.annotations.SerializedName;

public class Question {
    @SerializedName("id")
    private long Id;

    @SerializedName("IdAlgorithem")
    private long IdAlgorithem;

    @SerializedName("Question")
    private String Question;

    @SerializedName("State")
    private int State;

    @SerializedName("QuestionOrder")
    private int QuestionOrder;

    @Override
    public String toString() {
        return "Question{" +
                "Id=" + Id +
                ", IdAlgorithem=" + IdAlgorithem +
                ", Question='" + Question + '\'' +
                ", State=" + State +
                ", QuestionOrder=" + QuestionOrder +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public long getIdAlgorithem() {
        return IdAlgorithem;
    }

    public void setIdAlgorithem(long idAlgorithem) {
        IdAlgorithem = idAlgorithem;
    }

    public String getQuestion() {
        return Question;
    }

    public void setQuestion(String question) {
        Question = question;
    }

    public int getState() {
        return State;
    }

    public void setState(int state) {
        State = state;
    }

    public int getQuestionOrder() {
        return QuestionOrder;
    }

    public void setQuestionOrder(int questionOrder) {
        QuestionOrder = questionOrder;
    }
}
