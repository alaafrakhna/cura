package com.example.testretrofit;
// saaa7
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import java.util.List;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
public class MainActivity extends AppCompatActivity {
    Button button;
    TextView show;
    private static final String BASE_URL = "http://cura.eastus.cloudapp.azure.com/";
    // http://www.mocky.io/v2/5cd087d0320000b52100fd50 https://192.168.1.111:44374/api/user
    // http://cura.eastus.cloudapp.azure.com/api/user/getAllUsers
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        show=(TextView)findViewById(R.id.showUsers);
        button = (Button) findViewById(R.id.getUsers);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                show.setText("users List\n");
                try {
                    Retrofit retrofit = new
                            Retrofit.Builder().baseUrl(BASE_URL).addConverterFactory(GsonConverterFactory.create()).build
                            ();
                    MyApiEndPointInterface apiService =
                            retrofit.create(MyApiEndPointInterface.class);
                    Call<List<UserInfo>> repos =
                            apiService.getAllUsers();
                    repos.enqueue(new Callback<List<UserInfo>>() {
                        @Override
                        public void onResponse(Call<List<UserInfo>> call,
                                               Response<List<UserInfo>> response) {
                            int statusCode = response.code();
                            List<UserInfo> usersObjects= response.body();
                            for (int i = 0; i < usersObjects.size(); i++) {

                                show.setText(show.getText()+usersObjects.get(i).getName()+"\n");
                            }
                        }
                        @Override
                        public void onFailure(Call<List<UserInfo>> call, Throwable t) {
                            // Log error here since request failed
                            Toast.makeText(MainActivity.this,"error",Toast.LENGTH_LONG).show();
                        }
                    });
                }catch(Exception e)
                {
                }
            }
        });
    }
}