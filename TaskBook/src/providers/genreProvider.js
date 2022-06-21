import GenreMapper from "../models/mappers/genreMapper"

export default class BookProvider{
    static url = 'https://localhost:5001/Genres/'
    static statusOk = 200

    static async getGenres(){
        const result = await fetch(this.url+'getgenres', {method : 'GET', headers : {'Authorization' : "Bearer " + localStorage.getItem('testTaskBookToken')}})
        if(result.status === this.statusOk){
            const data = await result.json()
            return GenreMapper.mapGenres(data)
        }
    }
}