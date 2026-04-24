# DSA Repo Structure Design

**Date:** 2026-04-24
**Sheet:** https://takeuforward.org/dsa/strivers-a2z-sheet-learn-dsa-a-to-z
**Language:** C# (.NET)

## Goal

A GitHub repo to track daily DSA solutions while following Striver's A2Z sheet. One solution file per problem, one root README with a manual progress table.

## Folder Structure

Mirror the sheet's exact sub-groupings. Use Easy/Medium/Hard only where the sheet uses difficulty. Use sub-topic folders where the sheet uses sub-topics. Use flat folders elsewhere.

| Topic | Sub-folders |
|-------|-------------|
| Basics | flat |
| Sorting | flat |
| Arrays | Easy / Medium / Hard |
| BinarySearch | 1DArrays / SearchSpace / 2DArrays |
| Strings | Basic / Medium |
| LinkedList | SingleLL / DoubleLL / Hard |
| Recursion | flat |
| BitManipulation | flat |
| StackQueue | Learning / Monotonic |
| SlidingWindow | flat |
| Heaps | flat |
| Greedy | Easy / MediumHard |
| BinaryTrees | Traversals / Medium / Hard |
| BST | flat |
| Graphs | BFSDFS / TopoSort / MST / ShortestPath |
| DP | 1D / 2D / Strings / Stocks / LIS / Partition |
| Tries | flat |

## File Naming

`ProblemName.cs` — clean name, PascalCase, no numbers or difficulty suffix.

## README

Single root `README.md` with a manual progress table: Topic | Solved | Total. No per-folder READMEs.

## .gitignore

Standard C# ignores: `bin/`, `obj/`, `.vs/`, `*.user`.
