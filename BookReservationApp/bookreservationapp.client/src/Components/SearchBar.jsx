import React from 'react';

const SearchBar = ({ query, setQuery }) => {
    return (
        <input
            type="text"
            placeholder="Search for a book..."
            value={query}
            onChange={(e) => setQuery(e.target.value)} 
            className="form-control mb-3"
        />
    );
};

export default SearchBar;