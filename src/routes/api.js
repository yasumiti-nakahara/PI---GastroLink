const express = require('express');
const router = express.Router();
const Usuario = require('../models/Usuario');
const Proposta = require('../models/Proposta');

// Rota 1: Listar todos os Influenciadores (Para a tela de Descoberta)
router.get('/influencers', async (req, res) => {
    try {
        const influencers = await Usuario.find({ tipo: 'influencer' });
        res.status(200).json(influencers);
    } catch (erro) {
        res.status(500).json({ erro: 'Erro ao buscar influenciadores' });
    }
});

// Rota 2: Criar uma nova Proposta de Divulgação (O Match)
router.post('/propostas', async (req, res) => {
    try {
        const { restauranteId, influencerId, mensagem } = req.body;

        const novaProposta = new Proposta({
            restauranteId,
            influencerId,
            mensagem
        });

        await novaProposta.save();
        res.status(201).json({ mensagem: 'Proposta enviada com sucesso!', proposta: novaProposta });
    } catch (erro) {
        res.status(500).json({ erro: 'Erro ao enviar proposta' });
    }
});

module.exports = router;