import React, { useEffect, useState } from 'react';

const AbonnementList = () => {
    const [abonnements, setAbonnements] = useState([]);

    useEffect(() => {
        fetch('/api/abonnements')
            .then(response => response.json())
            .then(data => setAbonnements(data))
            .catch(error => console.error('Erreur:', error));
    }, []);

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