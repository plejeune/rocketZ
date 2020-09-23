using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using FullSerializer;
using UnityEngine.Serialization;

public class UserController : MonoBehaviour {

    public Text Info, scoreText, newScoreText;
    public GameObject infoBox, switchText, logPanel, btnWhenLogged, logBtn, signBtn, connectBtn, creaText, scoreFolder, usernameField;
    public InputField getScoreText, emailText, usernameText, passwordText;

    private string databaseURL = "https://test-5ff15.firebaseio.com/users";
    private string AuthKey = "AIzaSyBFdzIDmvQiUH5xCanIcxNX3_uNNF52qZ0";
    private string idToken, getLocalId;

    public static int playerScore, newScore;
    public static string playerName, localId;
    public static fsSerializer serializer = new fsSerializer();

    public int points;

    User user = new User();

    void Start () {
        points = Random.Range(1000, 1500);
        newScore = 0;
        newScoreText.text = "" + newScore;
        scoreText.text = "" + playerScore;
	}

    //Increase score - regular item
    public void winPoint()
    {
        newScore += points;
        newScoreText.text = "" + newScore;
        playerScore = user.userScore;
    }

    //Increase score - special item
    public void winPointSpecial()
    {
        newScore += 10000;
        newScoreText.text = "" + newScore;
        playerScore = user.userScore;
    }

    /*
    //Increase score
    public void winPoint()
    {
        user.userScore += 1;
        scoreText.text = "" + user.userScore;
        playerScore = user.userScore;
    }
    */

    public void Save()
    {
        if (newScore > playerScore)
        {
            playerScore = newScore;

            //Info.GetComponent<Text>().text = "Sauvegarde réussie.";
            //infoBox.GetComponent<Animation>().Play("infoAnim");

            PostToDatabase();
        }
    }

    public void OnGetScore()
    {
        GetLocalId();
    }

    private void UpdateScore()
    {
        scoreText.text = "" + user.userScore;
    }

    //REST API //POST PUT
    public void PostToDatabase(bool emptyScore = false)
    {
        User user = new User();

        if(emptyScore)
        {
            user.userScore = 0;
        }

        RestClient.Put(databaseURL + "/" + localId + ".json?auth=" + idToken, user);
    }

    //REST API //GET
    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>(databaseURL + "/" + getLocalId + ".json?auth=" + idToken).Then(response => {
            user = response;
            UpdateScore();
        });

        //Info.GetComponent<Text>().text = "Chargement des données réussie.";
        //infoBox.GetComponent<Animation>().Play("infoAnim");
    }

    public void SignUpUserButton() {
        SignUpUser(emailText.text, usernameText.text, passwordText.text);
    }

    public void SignInUserButton()
    {
        SignInUser(emailText.text, passwordText.text);
    }

    //SIGN UP A USER //INSCRIPTION
    private void SignUpUser(string email, string username, string password)
    {
        if (usernameText.text != "" && switchText.activeSelf == true)
        {
            string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
            RestClient.Post<Response>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key=" + AuthKey, userData).Then(
                response =>
                {
                    Info.GetComponent<Text>().text = "Compte créé avec succès !";
                    Info.GetComponent<Text>().color = Color.green;
                    infoBox.GetComponent<Animation>().Play("infoAnim");

                    switchText.SetActive(false);
                    usernameField.SetActive(false);
                    connectBtn.SetActive(true);
                    signBtn.SetActive(false);
                    creaText.SetActive(true);

                    idToken = response.idToken;
                    localId = response.localId;
                    playerName = username;
                    PostToDatabase(true);

                }).Catch(error =>
            {
                Debug.Log(error);

                Info.GetComponent<Text>().text = "Oups. Il y a eu un petit problème.";
                Info.GetComponent<Text>().color = Color.yellow;
                infoBox.GetComponent<Animation>().Play("infoAnim");
            });
        }

        else
        {
            Info.GetComponent<Text>().text = "Vous devez remplir tous les champs.";
            Info.GetComponent<Text>().color = Color.yellow;
            infoBox.GetComponent<Animation>().Play("infoAnim");
        }
    }

    //SIGN IN //LOGIN
    private void SignInUser(string email, string password)
    {      
        string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
            RestClient.Post<Response>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=" + AuthKey, userData).Then(
                response =>
                {
                    
                    logPanel.SetActive(false);
                    logBtn.SetActive(false);
                    btnWhenLogged.SetActive(true);
                    scoreFolder.SetActive(true);

                    idToken = response.idToken;
                    localId = response.localId;

                    Info.GetComponent<Text>().text = "Vous êtes connecté.";
                    Info.GetComponent<Text>().color = Color.green;
                    infoBox.GetComponent<Animation>().Play("infoAnim");

                    getScoreText.text = "" + response.localId;

                    GetUsername();
                    OnGetScore();

                }).Catch(error =>
            {
                Debug.Log(error);

                Info.GetComponent<Text>().text = "Erreur. Email ou mot de passe incorrect.";
                Info.GetComponent<Text>().color = Color.red;
                infoBox.GetComponent<Animation>().Play("infoAnim");
            });    

    }

    //GET USER
    private void GetUsername()
    {
        RestClient.Get<User>(databaseURL + "/" + localId + ".json?auth=" + idToken).Then(response => {

            playerName = response.userName;

        });
    }

    //GET LOCAL ID (UNIQUE ID OF THE PLAYER)
    private void GetLocalId()
    {
        RestClient.Get(databaseURL + ".json?auth=" + idToken).Then(response => {

            var username = getScoreText.text;

            fsData userData = fsJsonParser.Parse(response.Text);
            Dictionary<string, User> users = null;
            serializer.TryDeserialize(userData, ref users);

            foreach(var user in users.Values)
            {
                if(user.localId == username)
                {
                    getLocalId = user.localId;
                    RetrieveFromDatabase();
                    break;
                }

                if(user.userScore > 0)
                {

                }
            }

        }).Catch(error => {

            Debug.Log(error);
        });
    }
}
