# Week 8: Midterm Exam

> **Template Purpose:** This is the midterm exam template. You should have studied the w07-midterm-prep template before taking this exam.

---

## Overview

This is the in-class midterm exam. You will extend the RPG combat system so that equipped items affect attack, defense, and other stats during battles. This exam tests your understanding of LINQ, interfaces, inheritance, and SOLID principles from Weeks 1-7.

## Learning Objectives

By completing this exam, you will demonstrate:
- [ ] Using LINQ to calculate bonuses from equipped items
- [ ] Applying the Open/Closed Principle by extending combat logic
- [ ] Working with object relationships and navigation properties
- [ ] Understanding how abstract classes and inheritance work together

## Prerequisites

Before starting, ensure you have:
- [ ] Reviewed the Week 7 midterm prep template
- [ ] Understanding of LINQ (`Where`, `Select`, `Sum`)
- [ ] Understanding of interfaces and abstract classes
- [ ] Working knowledge of the ConsoleRPG codebase

## Project Structure

This template uses a **two-project architecture**:

```
ConsoleRpgFinal.sln
│
├── ConsoleRpg/                        # UI & Game Logic Project
│   ├── Program.cs                     # Entry point
│   ├── GameEngine.cs                  # Main game loop
│   ├── Services/
│   │   ├── BattleService.cs           # Combat logic (you'll work here!)
│   │   └── PlayerService.cs           # Player operations
│   └── UI/
│       └── ConsoleGameUi.cs           # Menu and display
│
└── ConsoleRpgEntities/                # Data & Models Project
    ├── Data/
    │   └── GameContext.cs             # Data context
    ├── Models/
    │   ├── Player.cs                  # Player entity (you'll work here!)
    │   ├── MonsterBase.cs             # Monster abstract base
    │   ├── Item.cs                    # Equipment items
    │   └── AbilityScores.cs           # Character stats
    └── Files/
        ├── players.json
        ├── monsters.json
        └── items.json
```

**Key files for the exam:**
- `ConsoleRpgEntities/Models/Player.cs` - Add `GetTotalAttack()` and `GetTotalDefense()`
- `ConsoleRpg/Services/BattleService.cs` - Review how combat uses these methods

## What's Being Tested

| Concept | Where You Learned It |
|---------|---------------------|
| LINQ queries | Weeks 3, 7 |
| Interfaces | Weeks 4-5 |
| Abstract classes | Week 6 |
| SOLID principles | Weeks 3-6 |
| File I/O (JSON) | Weeks 1-4 |

---

## Exam Tasks

### Task 1: Player Item-Driven Combat (Required)

**What you must do:**
- Read and understand the code in `BattleService.cs` and `Player.cs`
- Implement the `GetTotalAttack()` and `GetTotalDefense()` methods in `Player.cs`
- Use LINQ to sum bonuses from equipped items

**How equipped items affect combat:**
- Weapons (items with `Attack` modifier and `IsEquipped == true`) increase attack damage
- Armor (items with `Defense` modifier and `IsEquipped == true`) reduce incoming damage

**Example: Attack Calculation**
```csharp
int baseAttack = 5 + player.Level;
int itemAttackBonus = player.Items
    .Where(item => item.IsEquipped && item.AttributeModifiers != null)
    .Select(item => item.AttributeModifiers.TryGetValue(Attribute.Attack, out var bonus) ? bonus : 0)
    .Sum();
int totalAttack = baseAttack + itemAttackBonus;
```

**Example: Defense Calculation**
```csharp
int baseDefense = player.AbilityScores.Defense;
int itemDefenseBonus = player.Items
    .Where(item => item.IsEquipped && item.AttributeModifiers != null)
    .Select(item => item.AttributeModifiers.TryGetValue(Attribute.Defense, out var bonus) ? bonus : 0)
    .Sum();
int totalDefense = baseDefense + itemDefenseBonus;
```

**What you DO NOT need to change:**
- The attack/defense calculation logic in `BattleService.cs`
- The `Item` or `AbilityScores` classes

**Checklist:**
- [ ] Implemented `GetTotalAttack()` in `Player.cs`
- [ ] Implemented `GetTotalDefense()` in `Player.cs`
- [ ] Understand how equipped items affect attack and defense

---

## Stretch Goals

### Stretch Goal 1: Monster Item-Driven Combat (+10%)

Extend the item-driven combat to monsters:
- Add `GetTotalAttack()` and `GetTotalDefense()` methods to `MonsterBase.cs`
- Update how monsters are loaded and equipped with items
- Apply the same LINQ pattern used for players

**Example:**
```csharp
int monsterAttackBonus = monster.Items?
    .Where(item => item.IsEquipped && item.AttributeModifiers != null)
    .Select(item => item.AttributeModifiers.TryGetValue(Attribute.Attack, out var bonus) ? bonus : 0)
    .Sum() ?? 0;
```

### Stretch Goal 2: Consumable Items (+20%)

Implement consumable items (potions) that restore health:
- Create a method to use consumable items
- Integrate with the battle system or menu
- Handle item consumption (remove or decrease quantity)

---

## Grading Rubric

| Criteria | Points | Description |
|----------|--------|-------------|
| Player Item Combat | 60 | Correctly implements `GetTotalAttack()` and `GetTotalDefense()` |
| Code Quality | 20 | Clean, readable, follows existing patterns |
| Understanding | 20 | Can explain how the code works |
| **Total** | **100** | |
| **Stretch: Monster Combat** | **+10** | Item-driven combat for monsters |
| **Stretch: Consumables** | **+20** | Consumable item implementation |

---

## Exam Day Tips

- Read the requirements carefully before coding
- Start with the simplest task first
- Test frequently - don't write everything then test
- Use the patterns you see in existing code
- Follow the inline TODO comments in the codebase
- Ask for clarification if requirements are unclear

---

## Submission

1. Ensure your code compiles and runs
2. Commit your changes with a meaningful message
3. Push to your GitHub Classroom repository

---

## Resources

- [LINQ Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [Working with JSON](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
- [Open/Closed Principle](https://stackify.com/solid-design-open-closed-principle/)

---

## Need Help?

- Raise your hand during the exam
- Review the inline TODO comments in the code
- Check the examples in this README
