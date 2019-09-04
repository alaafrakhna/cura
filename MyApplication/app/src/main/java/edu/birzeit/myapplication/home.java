package edu.birzeit.myapplication;

        import android.content.Intent;
        import android.support.v7.app.AppCompatActivity;
        import android.os.Bundle;
        import android.view.View;
        import android.widget.Button;

/*
        Button button,Firststep,Home,instcare;

        instcare = (Button) findViewById(R.id.button5);
        instcare.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(MainActivity.this, Main2Activity.class);
                MainActivity.this.startActivity(intent);
            }
        });

        Firststep = (Button) findViewById(R.id.button3);
        Firststep.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(MainActivity.this, FirstStep.class);
                MainActivity.this.startActivity(intent);
            }
        });


        Home = (Button) findViewById(R.id.button4);
        Home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(MainActivity.this, home.class);
                MainActivity.this.startActivity(intent);
            }
        });

*/


public class home extends AppCompatActivity {
    Button Signin;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        Signin = (Button) findViewById(R.id.ContinueButton);
        Signin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent  = new Intent(home.this, logIn.class);
                home.this.startActivity(intent);
            }
        });


    }

}


