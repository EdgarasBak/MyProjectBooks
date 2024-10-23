
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import SearchBar from './SearchBar';
import './BookList.css';

const BookList = () => {
    const [books, setBooks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [search, setSearch] = useState('');
    const [filteredBooks, setFilteredBooks] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBooks = async () => {
            try {
                const response = await fetch('https://localhost:7284/api/book/GetAllBooks');
                if (!response.ok) throw new Error('Network response was not ok');
                const data = await response.json();
                setBooks(data);
                setFilteredBooks(data); 
            } catch (error) {
                console.error('Error fetching books:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchBooks();
    }, []);

    const handleReserve = (book) => {
        navigate('/add-reservation', { state: { book } });
    };

    const handleSearch = () => {
        const lowerCaseSearch = search.toLowerCase();
        const searchYear = parseInt(search, 10);

        const results = books.filter(book => {
            console.log('Current book:', book); 
            const bookNameMatches = book.name.toLowerCase().includes(lowerCaseSearch);
            const bookYearMatches = Number.isInteger(searchYear) && book.year === searchYear;
            const bookTypeMatches = book.type && book.type.toLowerCase().includes(lowerCaseSearch); 

            return bookNameMatches || bookYearMatches || bookTypeMatches;
        });

        console.log('Filtered results:', results); 
        setFilteredBooks(results);
    };

    if (loading) return <p>Loading...</p>;

    return (
        <div>
            <h2>Book List</h2>
            <SearchBar query={search} setQuery={setSearch} />
            <button className="btn btn-secondary mb-3" onClick={handleSearch}>Search</button>
            <div className="row">
                {filteredBooks.length > 0 ? (
                    filteredBooks.map((book) => (
                        <div className="col-md-4 mb-3" key={book.id}>
                            <div className="card">
                                <img src={book.pictureUrl} className="card-img-top" alt={book.name} />
                                <div className="card-body">
                                    <h5 className="card-title">{book.name}</h5>
                                    <p className="card-text">Year: {book.year}</p>
                                    <button className="btn btn-primary" onClick={() => handleReserve(book)}>Reserve</button>
                                </div>
                            </div>
                        </div>
                    ))
                ) : (
                    <p>No books found matching your search criteria.</p>
                )}
            </div>
        </div>
    );
};

export default BookList;
