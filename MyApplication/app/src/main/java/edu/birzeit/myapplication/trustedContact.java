package edu.birzeit.myapplication;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import java.util.ArrayList;
import java.util.List;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import edu.birzeit.myapplication.models.TrustedContact;
import android.widget.ListView;
import android.widget.Button;
import android.content.Intent;
import android.view.View;
import android.widget.Toast;

public class trustedContact extends AppCompatActivity {
    ListView trustContactListView;
    Button btnAddUser;


    List<TrustedContact> list = new ArrayList<TrustedContact>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trusted_contact);



        btnAddUser = (Button) findViewById(R.id.btnAddUser);
        trustContactListView = (ListView) findViewById(R.id.listView);

        getUsersList();

        btnAddUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {


                Intent intent = new Intent(trustedContact.this, trustedContactActivity.class);
                intent.putExtra("trustContact_id",String.valueOf(-1));
                intent.putExtra("trustContact_name", "");
                intent.putExtra("trustContact_phone", "");
                intent.putExtra("trustContact_ContactOrder","");

                trustedContact.this.startActivity(intent);

            }
        });
    }


    public void getUsersList(){
        try {

            Call<List<TrustedContact>> repos = Api.getClient().getUserTrustedContact(logIn.userid);
            repos.enqueue(new Callback<List<TrustedContact>>() {

                @Override
                public void onResponse(Call<List<TrustedContact>> call, Response<List<TrustedContact>> response) {

                    List<TrustedContact> TrustContactObjects= response.body();


                    trustContactListView.setAdapter(new TrustedContactAdapter(trustedContact.this, R.layout.list_trusted_contact, TrustContactObjects));

                }
                @Override
                public void onFailure(Call<List<TrustedContact>> call, Throwable t) {
                    // Log error here since request failed
                    Toast.makeText(trustedContact.this,"error",Toast.LENGTH_LONG).show();
                }
            });
        }catch(Exception e)
        {
        }

    }

}

