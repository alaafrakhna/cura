package edu.birzeit.myapplication.models;



import com.google.gson.annotations.SerializedName;

public class QustionAnswer {
    @SerializedName("id")
    private long Id;

    @SerializedName("IdRecord")
    private long IdRecord;

    @SerializedName("Answer")
    private String Answer;

    @SerializedName("IdQuestion")
    private long IdQuestion;

    @SerializedName("AnswerApproved")
    private String AnswerApproved;

    @Override
    public String toString() {
        return "QustionAnswer{" +
                "Id=" + Id +
                ", IdRecord=" + IdRecord +
                ", Answer='" + Answer + '\'' +
                ", IdQuestion=" + IdQuestion +
                ", AnswerApproved='" + AnswerApproved + '\'' +
                '}';
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public long getIdRecord() {
        return IdRecord;
    }

    public void setIdRecord(long idRecord) {
        IdRecord = idRecord;
    }

    public String getAnswer() {
        return Answer;
    }

    public void setAnswer(String answer) {
        Answer = answer;
    }

    public long getIdQuestion() {
        return IdQuestion;
    }

    public void setIdQuestion(long idQuestion) {
        IdQuestion = idQuestion;
    }

    public String getAnswerApproved() {
        return AnswerApproved;
    }

    public void setAnswerApproved(String answerApproved) {
        AnswerApproved = answerApproved;
    }
}
