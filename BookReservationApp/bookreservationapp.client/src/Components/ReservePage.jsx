import React from 'react';
import ReservationForm from './ReservationForm'; 

const ReservePage = ({ book }) => {
    const handleReserve = async (reservation) => {
        const response = await fetch('https://localhost:7284/api/reservation/AddReservation', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(reservation),
        });

        if (response.ok) {
            const data = await response.json();
            alert(`Reservation successful! Total Cost: €${data.totalCost.toFixed(2)}`);
        } else {
            console.error('Failed to reserve the book');
        }
    };

    return (
        <div className="container mt-4">
            <h2>Reserve {book.name}</h2>
            <ReservationForm onSubmit={handleReserve} book={book} />
        </div>
    );
};

export default ReservePage;
