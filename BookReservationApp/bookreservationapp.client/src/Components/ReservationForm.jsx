import React, { useState } from 'react';

const ReservationForm = ({ onSubmit, book }) => {
    const [days, setDays] = useState(0);
    const [bookType, setBookType] = useState('Book'); 
    const [quickPickUp, setQuickPickUp] = useState(false);

    const handleDaysChange = (e) => {
        setDays(parseInt(e.target.value) || 0);
    };

    const handleTypeChange = (e) => {
        setBookType(e.target.value);
        console.log("Selected Book Type:", selectedType);
    };

    const handleQuickPickUpChange = () => {
        setQuickPickUp(!quickPickUp);
    };

    const handleReserve = async (e) => {
        e.preventDefault();
        const selectedType = bookType === 'Audiobook' ? 1 : 0;
        const reservation = {
            bookId: book.id,
            bookName: book.name,
            days: days,
            quickPickUp: quickPickUp,
            selectedType: selectedType,
        };
        console.log("Submitting reservation:", reservation);

        await onSubmit(reservation); 
    };

    return (
        <form onSubmit={handleReserve}>
            <div className="form-group">
                <label>Days</label>
                <input
                    type="number"
                    className="form-control"
                    value={days}
                    onChange={handleDaysChange}
                    required
                />
            </div>

            <div className="form-group">
                <label>Type</label>
                <select
                    className="form-control"
                    value={bookType}
                    onChange={handleTypeChange}
                >
                    <option value="Book">Book</option>
                    <option value="Audiobook">Audiobook</option>
                </select>
            </div>

            <div className="form-group">
                <label>
                    <input
                        type="checkbox"
                        checked={quickPickUp}
                        onChange={handleQuickPickUpChange}
                    />
                    Quick Pick Up
                </label>
            </div>

            <button type="submit" className="btn btn-primary">Reserve</button>
        </form>
    );
};

export default ReservationForm;
