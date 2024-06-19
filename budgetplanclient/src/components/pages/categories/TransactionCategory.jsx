import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";
import {useEffect, useState} from "react";

function TransactionCategory() {

    const { getListTransactionCategories, addOverTransactionCategory, addTransactionCategory, deleteTransactionCategory } = useTransactionCategoriesApi();

    const [categories, setCategories] = useState([]);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const data = await getListTransactionCategories();
                setCategories(data.overTransactionCategoryList || []);
            } catch (error) {
                setCategories([])
                console.error('Error fetching transaction categories:', error);
            }
        };

        fetchCategories();
    }, []);

    return (
        <div className={'container'}>
            <div>
                <h1>Transaction Categories</h1>
                <ul>
                    {categories.map(category => (
                        <li key={category.id}>
                            {category.transactionCategoryName}
                            <ul>
                                {category.transactionCategoryDtos.map(subCategory => (
                                    <li key={subCategory.id}>
                                        {subCategory.transactionCategoryName}
                                    </li>
                                ))}
                            </ul>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default TransactionCategory;