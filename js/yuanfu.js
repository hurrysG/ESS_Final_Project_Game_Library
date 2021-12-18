let gameLibraryUrl = "http://localhost:5000/api/GameLibrary"
let developerUrl = "http://localhost:5000/api/Developer"
let publisherUrl = "http://localhost:5000/api/Publisher"
let DEVELOPERS = []
let PUBLISHERS = []

function initUpdateGamePage() {
    // alert("Load Page")
    let gameId = localStorage.getItem('gameId')
    let messageComponent = document.getElementById('game-not-existing')
    let formComponent = document.getElementById('game-existing')

    gameId = "8AB7A83B-9893-4574-9793-F7769BA00894"

    if (gameId != null) {
        // show form and hide message
        formComponent.classList.remove('d-none')
        messageComponent.classList.add('d-none')
        showUpdateForm(true)

        // fetch game object
        fetch(`${gameLibraryUrl}/${gameId}`, {
            headers: {
                "Content-Type": "application/json"
            },
            method: "GET"
        })
            .then(response => {
                console.log(response)
                if (response.status === 200) {
                    return response.json()
                }
                else {
                    return null
                }
            })
            .then(data => {
                console.log(data)
                displayGameToUpdateGameForm(data)
            })

    }
    else {
        // show message and hide form
        showUpdateForm(false)
    }
}

async function displayGameToUpdateGameForm(game) {
    let inputGameName = document.getElementById('inputGameName')
    let inputGenre = document.getElementById('inputGenre')
    let inputConsole = document.getElementById('inputConsole')
    let selectDeveloper = document.getElementById('selectDeveloper')
    let selectPublisher = document.getElementById('selectPublisher')
    await getAllDevelopers()
    await getAllPublishers()
    selectDeveloper.innerHTML = ""

    for (var i in game.developers) {
        let divRow = document.createElement("div")
        divRow.classList.add("row")
        let select = document.createElement("select")
        select.classList.add("form-control")
        select.classList.add("col-10")
        select.classList.add("m-3")
        select.name = "developer"

        for (var j in DEVELOPERS) {
            let option = document.createElement("option")
            option.value = DEVELOPERS[j].id
            option.text = DEVELOPERS[j].name
            if (game.developers[i].id === DEVELOPERS[j].id) {
                option.selected = true
            }
            select.appendChild(option)
        }

        divRow.appendChild(select)

        let btnRemove = document.createElement("button")
        btnRemove.type = "button"
        btnRemove.classList.add("btn")
        btnRemove.classList.add("btn-danger")
        btnRemove.classList.add("col-1")
        btnRemove.classList.add("m-3")
        btnRemove.addEventListener("click", removeDeveloper)
        btnRemove.textContent = "Remove"

        divRow.appendChild(btnRemove)
        selectDeveloper.appendChild(divRow)
    }

    inputGameName.value = game.name
    inputGenre.value = game.genre
    inputConsole.value = game.console

    for (var i in PUBLISHERS) {
        let option = document.createElement("option")
        option.value = PUBLISHERS[i].id
        option.text = PUBLISHERS[i].name
        if (game.publisher.id === PUBLISHERS[i].id) {
            option.selected = true
        }
        selectPublisher.appendChild(option)
    }

}

function removeDeveloper(e) {
    e.target.parentElement.remove()
}

async function getAllDevelopers() {
    const response = await fetch(`${developerUrl} `, {
        headers: {
            "Content-Type": "application/json"
        },
        method: "GET"
    })
    const json = await response.json()
    DEVELOPERS = json
    console.log(json)
}

async function getAllPublishers() {
    const response = await fetch(`${publisherUrl} `, {
        headers: {
            "Content-Type": "application/json"
        },
        method: "GET"
    })
    const json = await response.json()
    PUBLISHERS = json
    console.log(json)
}

function getDeveloperSelect(developer) {
    let controlTemplate = `< div class="row" >
    <select class="form-control col-10 m-3" name="developer">
    </select>
    <button type="button" class="btn btn-danger col-1 m-3"
        onclick="removeDeveloper()">Remove</button>
    </div > `
    let select = document.createElement("select").classList.add("form-group")
    select
}

let showUpdateForm = function (isShown) {
    let messageComponent = document.getElementById('game-not-existing')
    let formComponent = document.getElementById('game-existing')
    if (isShown) {
        formComponent.classList.remove('d-none')
        messageComponent.classList.add('d-none')
    }
    else {
        formComponent.classList.add('d-none')
        messageComponent.classList.remove('d-none')
    }
}

function update() {
    console.log("update")
    let inputGameName = document.getElementById('inputGameName')
    let inputGenre = document.getElementById('inputGenre')
    let inputConsole = document.getElementById('inputConsole')
    let selectDeveloper = document.getElementsByName('developer')
    let selectPublisher = document.getElementById('selectPublisher')
    console.log(selectDeveloper)

    let body = {}
    body.name = inputGameName.value
    body.genre = inputGenre.value
    body.console = inputConsole.value
    body.developers = []

    for (var i = 0; i < selectDeveloper.length; i++) {
        body.developers.push({ "id": selectDeveloper[i].value })
    }
    body.publisher = selectPublisher.value

    console.log(body)
    fetch(gameLibraryUrl, {
        headers: {
            'Accept': 'application/json',
            "Content-Type": "application/json"
        },
        method: "PUT",
        body: JSON.stringify(body)
    })
        .then(response => {
            if (response.status == 200) {
                alert("Update Successfully")
            }
        })

}
