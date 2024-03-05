const express = require('express');
const router = express.Router();

// GET /products/new - Render form for creating a new product
router.get('/new', (req, res) => {
    res.send('New product page');
});

// POST /products - Create a new product
router.post('/', (req, res) => {
    // Code to handle creating a new product
    res.send('Product created');
});

// GET /products/:id - Retrieve details of a specific product
router.get('/:id', (req, res) => {
    const productId = req.params.id;
    res.send(`Product details page for ID: ${productId}`);
});

// GET /products - Retrieve all products
router.get('/', (req, res) => {
    try {
        // Code to fetch products from a database or any other data source
        const products = fetchProducts();

        // Render a view with the products data
        res.render('products', { products });
    } catch (error) {
        // Handle error
        console.error('Error fetching products:', error);
        res.status(500).send('Error fetching products');
    }
});

// DELETE /products/:id - Delete a product with the given ID
router.delete('/:id', (req, res) => {
    const productId = req.params.id;
    // Code to delete the product with the given ID from the database or any other data source
    res.send(`Product with ID ${productId} deleted`);
});

// PUT /products/:id - Update a product with the given ID
router.put('/:id', (req, res) => {
    const productId = req.params.id;
    // Code to update the product with the given ID in the database or any other data source
    res.send(`Product with ID ${productId} updated`);
});

module.exports = router;
