import Genre from '../genre'

export default class GenreMapper{

    static mapGenre(data){
        return new Genre(data.id, data.name)
    }

    static mapGenres(data){
        return data.map(genre=> {return this.mapGenre(genre)})
    }
}