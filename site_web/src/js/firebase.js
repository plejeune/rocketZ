(function() {
	
    const config = {databaseURL: "https://test-5ff15.firebaseio.com"};
    firebase.initializeApp(config);

    var table = document.querySelector('#table1 tbody'); 
    const scoreRef = firebase.database().ref().child('users');
    
    scoreRef.orderByChild("userScore").once('value', snap => {
      
        while(table.hasChildNodes()) {
            table.removeChild(table.firstChild);
        }

		var scores = Object.values(snap.val())
		scores.sort(function(a, b){
			if(a.userScore<b.userScore){
				return 1;
			}else if(a.userScore>b.userScore){
				return -1;
			}else{
				return 0;
			}
		});
      
        for(var i in scores) {          
            var row = table.insertRow(-1);          
            for(var j in scores[i]) {             
                cell = row.insertCell(-1);
                cell.innerHTML = scores[i][j];	
            }
        }
    });
    
}());


