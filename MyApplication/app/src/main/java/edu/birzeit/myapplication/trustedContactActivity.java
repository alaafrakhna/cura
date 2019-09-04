package edu.birzeit.myapplication;

import android.app.ProgressDialog;
        import android.content.Intent;
        import android.support.v7.app.AppCompatActivity;
        import android.os.Bundle;
        import android.view.MenuItem;
        import android.view.View;
        import android.widget.Button;
        import android.widget.EditText;
        import android.widget.Toast;
        import edu.birzeit.myapplication.models.TrustedContact;
        import retrofit2.Call;
        import retrofit2.Callback;
        import retrofit2.Response;


public class trustedContactActivity extends AppCompatActivity {


    EditText edtUId;
    EditText edtcontactname,editPhoneNumber,editcontactorder;
    Button btnSave;
    Button btnDel;

    Boolean CheckEditText;
  
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_trusted_contact2);


        getSupportActionBar().setDisplayHomeAsUpEnabled(true);


        edtUId = (EditText) findViewById(R.id.edtUId);
        edtcontactname = (EditText) findViewById(R.id.edtcontactname);
        editPhoneNumber = (EditText) findViewById(R.id.editPhoneNumber);
        editcontactorder = (EditText) findViewById(R.id.editcontactorder);
        btnSave = (Button) findViewById(R.id.btnSave);
        btnDel = (Button) findViewById(R.id.btnDel);


        Bundle extras = getIntent().getExtras();
        final String userId = extras.getString("trustContact_id");
        String userName = extras.getString("trustContact_name");
        String userPhone = extras.getString("trustContact_phone");
        final String userContactOrder = extras.getString("trustContact_ContactOrder");


        edtUId.setText(userId);
        edtcontactname.setText(userName);
        editPhoneNumber.setText(userPhone);
        editcontactorder.setText(userContactOrder);

        if ( Integer.parseInt(userId) != -1 ) {
            edtUId.setFocusable(false);
        } else {

            edtUId.setVisibility(View.INVISIBLE);
            btnDel.setVisibility(View.INVISIBLE);
        }


        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                long uId;
                TrustedContact u = new TrustedContact();

                u.setName(edtcontactname.getText().toString());
                u.setPhone(editPhoneNumber.getText().toString());
                u.setContactOrder(Integer.parseInt(editcontactorder.getText().toString()));
                uId=(Long.parseLong(edtUId.getText().toString()));
                u.setIdUser(logIn.userid);
                if (uId !=-1 )
                {
                    //update user
                    u.setId(uId);
                    updateUser(uId, u);
                } else
                    {
                    //add user
                    addUser(u);
                }


                Intent intent = new Intent(trustedContactActivity.this, trustedContact.class);
                startActivity(intent);
            }
        });

        btnDel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                long num=(Long.parseLong(edtUId.getText().toString()));

                deleteUser(num);

                Intent intent = new Intent(trustedContactActivity.this, trustedContact.class);
                startActivity(intent);


            }
        });

    }



    public void addUser(TrustedContact u){
        Call<TrustedContact> call = Api.getClient().addUserTrustedContact(u);
        call.enqueue(new Callback<TrustedContact>() {
            @Override
            public void onResponse(Call<TrustedContact> call, Response<TrustedContact> response) {
                if(response.isSuccessful()){
                    Toast.makeText(trustedContactActivity.this, "User created successfully!", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<TrustedContact> call, Throwable t) {
                Toast.makeText(trustedContactActivity.this, "Error , please try again.", Toast.LENGTH_LONG).show();
            }
        });
    }



    public void updateUser(long id, TrustedContact u){
        Call<TrustedContact> call = Api.getClient().UpdateUserTrustedContact(id, u);;
        call.enqueue(new Callback<TrustedContact>() {
            @Override
            public void onResponse(Call<TrustedContact> call, Response<TrustedContact> response) {
                if(response.isSuccessful()){
                    Toast.makeText(trustedContactActivity.this, "User updated successfully!", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<TrustedContact> call, Throwable t) {
                // display an error message
                Toast.makeText(trustedContactActivity.this, "Error , please try again.", Toast.LENGTH_LONG).show();
            }
        });
    }


    public void deleteUser(long id){
        Call<TrustedContact> call = Api.getClient().deleteUserTrustedContact(id);

        call.enqueue(new Callback<TrustedContact>() {
            @Override
            public void onResponse(Call<TrustedContact> call, Response<TrustedContact> response) {
                if(response.isSuccessful()){
                    Toast.makeText(trustedContactActivity.this, "User deleted successfully!", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<TrustedContact> call, Throwable t) {
                // display an error message
                Toast.makeText(trustedContactActivity.this, "Error , please try again.", Toast.LENGTH_LONG).show();
            }
        });
    }


    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                finish();
                return true;
        }

        return super.onOptionsItemSelected(item);
    }

   /* public void CheckEditTextIsEmptyOrNot() {

        Name = edtcontactname.getText().toString();
        Phone = editPhoneNumber.getText().toString();

        Order = Integer.parseInt(editcontactorder.getText().toString());

        if (TextUtils.isEmpty(Name) || TextUtils.isEmpty(Phone) || Order < 0) {

            CheckEditText = false;

        } else {

            CheckEditText = true;
        }
    }
    */

}








