// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onload = () => {

    let loginBtn = document.getElementById("auth");
    let regBtn = document.getElementById("tryReg");

    let info = document.getElementById("info");

    if (loginBtn) {



        loginBtn.addEventListener("click", () => {
            let login = document.getElementById("loginAuth").value;
            let password = document.getElementById("passwordAuth").value;

            
            if (login != "" && password != "") {

                let resp = JSON.stringify({
                    "email": login,
                    "password": password
                });

                info.innerText = "Проверяем..."

                fetch("/auth/login", {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json' 
                    },
                    body: resp,

                })
                    .then(response => {
                        if (response.ok) {
                            window.location.href = '/StaticPages/Tasks'
                        } else {
                            info.innerText = "Проверьте логин и пароль!"
                        }

                        
                        console.log(response);

                    })

                    .then(data => {
                        

                    })
                    .catch(error => {
                        console.log(error);
                        info.innerText = "Проверьте лоин и пароль!"
                      
                    })
            }
            console.log("click")

        })

    }


    if (regBtn) {

        regBtn.addEventListener("click", () => {
            console.log("reg btn")
            let login = document.getElementById("usernameRed").value;
            let email = document.getElementById("emailReg").value;
            let password = document.getElementById("passwordReg").value;


            if (login != "" && password != "" && password != "") {
                info.innerText = "Регистрируем";
                let resp = JSON.stringify({
                    "username": login,
                    "email": email,
                    "password": password
                });

                fetch("/auth/register", {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: resp,

                })
                    .then(response => {
                        if (response.ok) {
                            info.innerText = "Авторизируйтесь"
                        } else {
                            info.innerText = "Логин или почта возможно уже существуют, либо используйте более сложный пароль"
                        }

                    })

                    .catch(error => {
                        console.log(error);

                    })
            }
            console.log("click")

        })

    }



};