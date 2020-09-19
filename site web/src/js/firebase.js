(function() {
    const config = {
        //FIREBASE CONFIG
        apiKey: "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX_XXXXXXXXX",
        authDomain: "XXXXXX.firebaseapp.com",
        databaseURL: "https://XXXXXX.firebaseio.com",
        projectId: "XXXXXX",
        storageBucket: "XXXXXX.appspot.com",
        messagingSenderId: "XXXXXXXXXXXXX",
        appId: "1:XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
        measurementId: "G-XXXXXXXXXX"
    };

    firebase.initializeApp(config);

    var table = document.querySelector('#table1 tbody'); 
    const scoreRef = firebase.database().ref().child('users');
    
    scoreRef.orderByChild("userScore").once('value', snap => {
      
        while(table.hasChildNodes()) {
            table.removeChild(table.firstChild);
        }

        var scores = snap.val();
      
        for(var i in scores) {          
            var row = table.insertRow(-1);          
            for(var j in scores[i]) {             
                cell = row.insertCell(-1);
                cell.innerHTML = scores[i][j];
            }
        }
    });
    
}());


