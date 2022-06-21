export default class LoginProvider{
    static url = 'https://localhost:5001/token?'
    static statusOk = 200

    static async getToken(username,password){
        const result = await fetch(this.url+'username=' + username + "&password=" + password, {method : 'POST'})
        if(result.status === this.statusOk){
            const data = await result.json()
            localStorage.setItem('testTaskBookToken', data.access_token)
        }
    }
}