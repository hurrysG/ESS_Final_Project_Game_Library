let developerUrl = "http://localhost:5000/api/Developer"

function fetchAllDevelopers() {
    let developerWrapper = document.getElementById('developerWrapper')
    developerWrapper.innerHTML = ""

    fetch(`${developerUrl}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: "GET"
    })
        .then(response => {
            console.log(response)
            return response.json()
        })
        .then(data => {
            console.log(data)
            data.forEach(developer => {
                console.log(developer)
                let content = `<div id="developerWrapper" class="row">
                                <div class="col-10 m-3">
                                    <span class="h4">${developer.name}</span>
                                </div>
                            </div>`
                developerWrapper.innerHTML += content
            })
        })
}


function addDeveloper() {
    let developerName = document.getElementById('developerName')

    fetch(`${developerUrl}/${developerName.value}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: "POST"
    })
        .then(response => {
            fetchAllDevelopers()
        })
    // console.log(`${developerName.value}`)
}