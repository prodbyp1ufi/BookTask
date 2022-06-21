import AuthorMapper from "../models/mappers/authorMapper"

export default class BookProvider{
    static url = 'https://localhost:5001/Authors/'
    static statusOk = 200

    static async getAuthors(){
        const result = await fetch(this.url+'getauthors', {method : 'GET', headers : {'Authorization' : "Bearer " + localStorage.getItem('testTaskBookToken')}})
        if(result.status === this.statusOk){
            const data = await result.json()
            return AuthorMapper.mapAuthors(data)
        }
    }
}