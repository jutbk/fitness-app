// File: fitnessapp.client/src/components/AbonnementList.js
import React from 'react';

const abonnements = [
    { id: 1, type: 'Mensuel', price: '30€' },
    { id: 2, type: 'Trimestriel', price: '80€' },
    { id: 3, type: 'Annuel', price: '300€' }
];

const AbonnementList = () => {
    return (
        <div>
            <h2>Abonnements</h2>
            <ul>
                {abonnements.map(abonnement => (
                    <li key={abonnement.id}>
                        {abonnement.type} - {abonnement.price}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default AbonnementList;