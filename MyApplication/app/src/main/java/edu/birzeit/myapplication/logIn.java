package edu.birzeit.myapplication;

        import android.content.Intent;
        import android.support.v7.app.AppCompatActivity;
        import android.os.Bundle;
        import android.util.Log;
        import android.view.View;
        import android.widget.Button;
        import android.widget.EditText;
        import android.widget.TextView;
        import android.widget.Toast;

        import edu.birzeit.myapplication.models.Login;
        import edu.birzeit.myapplication.models.UserInfo;
        import retrofit2.Call;
        import retrofit2.Callback;
        import retrofit2.Response;

public class logIn extends AppCompatActivity {




    private static EditText emailid, password;
    private static Button loginButton;
    private static TextView  signUp;
    public static long  userid ;



    @Override
   protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_log_in);


        emailid = (EditText) findViewById(R.id.login_emailid);
        password = (EditText) findViewById(R.id.login_password);
        loginButton = (Button) findViewById(R.id.loginBtn);
        signUp = (TextView) findViewById(R.id.createAccount);




        signUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                    Intent intent  = new Intent(logIn.this, SignUp.class);
                    logIn.this.startActivity(intent);


            }
        });



        loginButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                checkValidation();
            }
        });

    }


    // Check Validation before login
    private void checkValidation() {

        // Get email id and password
        String getEmailId = emailid.getText().toString();
        String getPassword = password.getText().toString();

        Login l = new Login();
         l.setEmail(getEmailId);
         l.setPassword(getPassword);
        login(l);

    }




    public void login(Login l){
        try {


            Call<UserInfo> repos = Api.getClient().login(l);

            repos.enqueue(new Callback<UserInfo>() {

                @Override
                public void onResponse(Call<UserInfo> call, Response<UserInfo> response) {

                    UserInfo TrustContactObjects= response.body();

                    userid=TrustContactObjects.getId();

                    Intent intent  = new Intent(logIn.this, trustedContact.class);
                    logIn.this.startActivity(intent);


                }
                @Override
                public void onFailure(Call<UserInfo> call, Throwable t) {
                    // Log error here since request failed
                    Toast.makeText(logIn.this,"error",Toast.LENGTH_LONG).show();
                }
            });
        }catch(Exception e)
        {
        }

    }

}

