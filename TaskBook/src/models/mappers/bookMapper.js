import Book from '../book'

export default class BookMapper{

    static mapBook(data){
        return new Book(data.id, data.name, data.author, data.year, data.genre, data.authorId,data.genreId)
    }

    static mapBooks(data){
        return data.map(book=> {return this.mapBook(book)})
    }
}