const API_URL = 'http://localhost:5170/api';

document.addEventListener('DOMContentLoaded', () => {
    carregarRestaurantes();
});

async function carregarRestaurantes() {
    const contentContainer = document.querySelector('.content');
    const token = localStorage.getItem('token');

    if (!token) {
        alert('Você precisa estar logado para acessar a plataforma.');
        window.location.href = 'login.html';
        return;
    }

    try {
        const response = await fetch(`${API_URL}/Restaurantes`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            }
        });

        if (response.status === 401 || response.status === 403) {
            alert('Sessão expirada ou não autorizada.');
            window.location.href = 'login.html';
            return;
        }

        if (!response.ok) throw new Error('Erro ao buscar restaurantes');

        const restaurantes = await response.json();
        
        contentContainer.innerHTML = '';

        if (restaurantes.length === 0) {
            contentContainer.innerHTML = '<p style="grid-column: span 2; text-align: center; color: #777;">Nenhum restaurante disponível no momento.</p>';
            return;
        }

        restaurantes.forEach(restaurante => {
            const cardLink = document.createElement('a');
            cardLink.href = `restaurante.html?id=${restaurante.id}`;
            cardLink.className = 'card';

            cardLink.innerHTML = `
                <img src="${restaurante.fotoUrl || 'https://via.placeholder.com/150'}" alt="${restaurante.nomeRestaurante}" class="card-img">
                <div class="card-info">
                    <div class="card-title">${restaurante.nomeRestaurante}</div>
                    <div class="card-subtitle">${restaurante.categoria}</div>
                </div>
            `;

            contentContainer.appendChild(cardLink);
        });

    } catch (error) {
        console.error('Erro na integração com a Home:', error);
        contentContainer.innerHTML = '<p style="grid-column: span 2; text-align: center; color: #ff3b30;">Erro ao carregar dados do servidor.</p>';
    }
}