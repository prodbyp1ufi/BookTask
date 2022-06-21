import BookMapper from "../models/mappers/bookMapper"

export default class BookProvider{
    static url = 'https://localhost:5001/Books/'
    static statusOk = 200

    static async getBooks(){
        const result = await fetch(this.url+'getbooks', {method : 'GET', headers : {'Authorization' : "Bearer " +  localStorage.getItem('testTaskBookToken')}})
        if(result.status === this.statusOk){
            const data = await result.json()
            return BookMapper.mapBooks(data)
        }
    }

    static async editBook(bookBlank){
        const result = await fetch(this.url+'editbook', {method : 'POST', body: JSON.stringify(bookBlank), headers: {'Content-Type': 'application/json', 'Authorization' : "Bearer " +  localStorage.getItem('testTaskBookToken')}})
        return result.ok
    }removebooks

    static async addBook(bookBlank){
        bookBlank.id = 0
        const result = await fetch(this.url+'addbook', {method : 'POST', body: JSON.stringify(bookBlank), headers: {'Content-Type': 'application/json', 'Authorization' : "Bearer " + localStorage.getItem('testTaskBookToken')}})
        return result.ok
    }

    static async removeBooks(ids){
        const result = await fetch(this.url+'removebooks', {method : 'POST', body: JSON.stringify(ids), headers: {'Content-Type': 'application/json', 'Authorization' : "Bearer " +  localStorage.getItem('testTaskBookToken')}})
        return result.ok
    }
}