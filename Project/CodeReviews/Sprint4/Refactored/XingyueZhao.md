Xingyue Zhao
6/28/2019
Sprint4
ItemBlockCollisionHandler.cs and ItemBlockCollisionResolution.cs
Levi Zhou
1. Large Class: Both classes don't grow too large.
2. Feature Envy: nearly all methods it uses inherit from the GameObject class, and with this class, the overall code becomes simple and clean.
3. Inappropriate Intimacy: the class does not have inappropriate intimacy. Although this class uses of other methods from other classes, it does not need to know the implementation details.
4. Cyclomatic Complexity: The resolution class only have a switch case which I do not think it is too many branches.
5. The class should be divided more explicitly. For example, when the coin gets poped from the block, the coin itself will not move but only do its animation. However, the current resolution do not specify different types of items, which would behave differently in their resolution.
The class should have a call to call star do its movement. Also, as I said above, the classes, or their responses, should be explicitly seperated. 