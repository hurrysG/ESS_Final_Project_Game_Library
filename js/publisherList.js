let publisherUrl = "http://localhost:5000/api/Publisher"

function fetchAllPublishers() {
    let publisherWrapper = document.getElementById('publisherWrapper')
    publisherWrapper.innerHTML = ""

    fetch(`${publisherUrl}`, {
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
            data.forEach(publisher => {
                console.log(publisher)
                let content = `<div id="publisherWrapper" class="row">
                                <div class="col-10 m-3">
                                    <span class="h4">${publisher.name}</span>
                                </div>
                            </div>`
                publisherWrapper.innerHTML += content
            })
        })
}


function addPublisher() {
    let publisherName = document.getElementById('publisherName')

    fetch(`${publisherUrl}/${publisherName.value}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: "POST"
    })
        .then(response => {
            fetchAllPublishers()
        })
}