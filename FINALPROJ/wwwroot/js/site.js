fetch('http://localhost:5000/gamelibrary/', {
    method: "GET",
    headers: {
        "content-type": "application/json"
    }
})
    .then(response => response.json())
    .then(data => populateGameList(data));


function populateGameList(games){
    games.forEach(game => addGame(game)); 
    
}

function addGame(game){
    
    const outerUL = document.createElement('ul');
    //outerUL.setAttribute("id", "outerUL");
    //span.classList.add("close");
    //span.innerHTML = "&#x2715"
    outerUL.setAttribute("data-id", game.id);
    document.getElementById("gameDiv").appendChild(outerUL);


    const span = document.createElement('span');
    span.classList.add("close");
    span.innerHTML = "&#x2715"
    span.setAttribute("data-id", game.id);

    const outerLI = document.createElement('li');
    outerLI.innerHTML = game.name;
    outerLI.setAttribute("data-id", game.id);
    outerLI.appendChild(span);
    outerUL.appendChild(outerLI);



    const innerUL = document.createElement('ul');
    //span.classList.add("close");
    //span.innerHTML = "&#x2715"
    innerUL.setAttribute("data-id", game.id);
    outerLI.appendChild(innerUL);

    const innerSpan = document.createElement('span');
    innerSpan.classList.add("close");
    innerSpan.innerHTML = '&#x2715'
    innerSpan.setAttribute("data-id", game.id);

    const innerLi = document.createElement("li");
    innerLi.innerHTML = game.genre;
    innerLi.setAttribute("data-id", game.id);
    innerLi.appendChild(innerSpan);
    // const innerSpanTwo = document.createElement('span');
    // innerSpanTwo.classList.add("close");
    // innerSpanTwo.innerHTML = '&#x2715'
    // innerSpanTwo.setAttribute("data-id", game.id);
    const innerLiTwo = document.createElement("li");
    innerLiTwo.innerHTML = game.console;
    innerLiTwo.setAttribute("data-id", game.id);
    innerLiTwo.appendChild(innerSpan);
    const innerLiThree = document.createElement("li");
    innerLiThree.innerHTML = game.developers;
    innerLiThree.setAttribute("data-id", game.id);
    innerLiThree.appendChild(innerSpan);
    const innerLiFour = document.createElement("li");
    innerLiFour.innerHTML = game.publishers;
    innerLiFour.setAttribute("data-id", game.id);
    innerLiFour.appendChild(innerSpan);

    
    innerUL.appendChild(innerLi);
    innerUL.appendChild(innerLiTwo);
    innerUL.appendChild(innerLiThree);
    innerUL.appendChild(innerLiFour);
    
    
}

document.getElementById("add-button").addEventListener("click", () =>{
    fetch ('http://localhost:5000/GameLibrary/',{
        method: "POST",
        headers:  {"content-type": "application/json"
    },
    body: JSON.stringify({
        name: document.getElementById("gameName").value,
        genre: document.getElementById("gameGenre").value,
        console: document.getElementById("gameConsole").value,
        developers: document.getElementById("gameDevelopers").value,
        publishers: document.getElementById("gamePublishers").value
    })
})
    .then(response => response.json())
    .then(data => {
        addGame(data);
        document.getElementById("gameName").value = "";
        document.getElementById("gameGenre").value = "";
        document.getElementById("gameConsole").value = "";
        document.getElementById("gameDevelopers").value = "";
        document.getElementById("gamePublishers").value = "";
    })
    .catch(error => console.error('Unable to add item.', error));
});

